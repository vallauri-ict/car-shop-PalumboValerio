using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace VenditaVeicoliDLLProject
{
    [Serializable]
    public class SerializableBindingList<T> : BindingList<T> { }

    public class Utils
    {
        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = "|")
        {
            foreach (var o in objectlist)
            {
                FieldInfo[] fields = o.GetType().GetFields();
                PropertyInfo[] properties = o.GetType().GetProperties();

                yield return string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray());
            }
        }

        public static string ToCsvString<T>(IEnumerable<T> objectlist, string separator = "|")
        {
            StringBuilder csvdata = new StringBuilder();
            foreach (var o in objectlist)
            {
                FieldInfo[] fields = o.GetType().GetFields();
                PropertyInfo[] properties = o.GetType().GetProperties();

                csvdata.AppendLine(string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray()));
            }
            return csvdata.ToString();
        }

        public static void SerializeToCsv<T>(IEnumerable<T> objectlist, string pathName, string separator = "|")
        {
            IEnumerable<string> dataToSave = Utils.ToCsv(objectlist, separator);
            File.WriteAllLines(pathName, dataToSave);
        }

        public static void SerializeToXml<T>(SerializableBindingList<T> objectlist, string pathName)
        {
            XmlSerializer x = new XmlSerializer(typeof(SerializableBindingList<T>));
            TextWriter writer = new StreamWriter(pathName);
            x.Serialize(writer, objectlist);
        }

        public static void SerializeToJson<T>(IEnumerable<T> objectlist, string pathName)
        {
            string json = JsonConvert.SerializeObject(objectlist, Formatting.Indented);
            File.WriteAllText(pathName, json);            
        }

        public static void ParseJsonToObject(string pathName, SerializableBindingList<Veicoli> objectlist)
        {
            string json = File.ReadAllText(pathName);

            object[] veicoli = JsonConvert.DeserializeObject<object[]>(json);
            for (int i = 0; i < veicoli.Length; i++)
            {
                Moto moto = new Moto();
                Auto auto = new Auto();
                string veicolo = veicoli[i].ToString();
                if (veicolo.Contains("MarcaSella"))
                {
                    JsonConvert.PopulateObject(veicolo, moto);
                    objectlist.Add(moto);
                }
                else
                {
                    JsonConvert.PopulateObject(veicolo, auto);
                    objectlist.Add(auto);
                }
            }
        }

        public static void CreateHtml(SerializableBindingList<Veicoli> lista, string pathName, string skeletonPathName = @".\www\index-skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE AUTOVALLAURI - VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "Le migliori occasioni al miglior prezzo!");
            

            string aus = "<h3> LISTA DEI VEICOLI DISPONIBILI </h3>";
            for (int i = 0; i < lista.Count; i++)
                createBody(ref aus, lista, i);

            html = html.Replace("{{main-content}}", aus);
            File.WriteAllText(pathName, html);
        }

        private static void createBody(ref string aus, SerializableBindingList<Veicoli> lista, int i)
        {
            string veicolo = string.Empty;
            string usato;
            string km0 = string.Empty;

            if (lista[i].IsKmZero)
                km0 = "Chilometro zero<br>";
                

            if (lista[i].IsUsato)
                usato = "Usato";
            else
                usato = "Nuovo";

            if (lista[i] is Moto)
                veicolo = "moto.jpg";
            else
                veicolo = "auto.jpg";

            aus += "<div class = \"veicolo\">";
            aus += $"<img src = \"img/{veicolo}\">";
            aus += $"<div class = \"titolo\">{lista[i].Marca} {lista[i].Modello}";
            aus += $"<div class = \"didascalia\"> Colore: {lista[i].Colore}<br> Cilindrata: {lista[i].Cilindrata}<br> Immatricolazione: {lista[i].Immatricolazione}<br> {km0} {usato}<br> Chilometri percorsi: {lista[i].KmPercorsi}<br> Potenza: {lista[i].PotenzaKw} </div>";
            aus += "</div>";
            aus += "</div>";
        }
    }
}
