#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
#endregion

namespace VenditaVeicoliDLLProject
{
    #region SerializableBindingList
    [Serializable]
    public class SerializableBindingList<T> : BindingList<T> { }
    #endregion

    #region Utilities
    public class Utilities
    {
        /// <summary>
        /// Serialize an object list into Json string
        /// </summary>
        /// <param name="objectlist"> List to convert into Json string </param>
        /// <param name="pathName"> Json file path </param>
        public static void SerializeToJson<T>(IEnumerable<T> objectlist, string pathName)
        {
            string json = JsonConvert.SerializeObject(objectlist, Formatting.Indented);
            File.WriteAllText(pathName, json);            
        }

        /// <summary>
        /// Parse a Json string into an object list
        /// </summary>
        /// <param name="pathName"> Json file path </param>
        /// <param name="objectlist"> List to fill with json string elements </param>
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

        /// <summary>
        /// Create the html
        /// </summary>
        /// <param name="objectList"> List with datas </param>
        /// <param name="pathName"> index.html path </param>
        /// <param name="skeletonPathName"> Auxiliary index.html </param>
        public static void CreateHtml(SerializableBindingList<Veicoli> objectList, string pathName, string skeletonPathName = @".\www\index-skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE AUTOVALLAURI - VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "Le migliori occasioni al miglior prezzo!");
            

            string mainContent = "<h3> LISTA DEI VEICOLI DISPONIBILI </h3>";
            for (int i = 0; i < objectList.Count; i++)
                CreateBody(ref mainContent, objectList, i);

            html = html.Replace("{{main-content}}", mainContent);
            File.WriteAllText(pathName, html);
        }
        
        /// <summary>
        /// Create body for the html file
        /// </summary>
        /// <param name="mainContent"> Content to add </param>
        /// <param name="objectList"> List with datas </param>
        /// <param name="i"> List data position </param>
        private static void CreateBody(ref string mainContent, SerializableBindingList<Veicoli> objectList, int i)
        {
            string veicolo;
            string usato;
            string km0 = string.Empty;

            if (objectList[i].IsKmZero)
                km0 = "Chilometro zero<br>";
                

            if (objectList[i].IsUsato)
                usato = "Usato";
            else
                usato = "Nuovo";

            
            if (objectList[i] is Moto)
                veicolo = "moto.jpg";
            else
                veicolo = "auto.jpg";

            mainContent += "<div class = \"veicolo\">";
            mainContent += $"<img src = \"img/{veicolo}\">";
            mainContent += $"<div class = \"titolo\">{objectList[i].Marca} {objectList[i].Modello}";
            mainContent += $"<div class = \"didascalia\"> Colore: {objectList[i].Colore}<br> Cilindrata: {objectList[i].Cilindrata}<br> Immatricolazione: {objectList[i].Immatricolazione}<br> {km0} {usato}<br> Chilometri percorsi: {objectList[i].KmPercorsi}<br> Potenza: {objectList[i].PotenzaKw} </div>";
            mainContent += "</div>";
            mainContent += "</div>";
        }
    }
    #endregion
}
