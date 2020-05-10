# CarShop 

A carshop menagement software

--------------------------------
*Project version: __6.0.3__*

*Project specifics:*
1. Windows Forms Project
	- Add, Delete, Modify and Save the vehicles datas
    - Open a json file with vehicles datas;
	- Create html with vehicles datas.
2. Console Project
	- Create two tables in an Access project;
	- You can insert in the tables more personal datas;
	- You can visualize the tables in console;
	- You can modify a data in the tables;
	- You can remove datas in the tables;
	- You can delete the tables.

--------------------------------

### FormUtilities
*List of public methods:*
```csharp
public static void SerializeToJson<T>(IEnumerable<T> objectlist, string pathName){}
public static void ParseJsonToObject(string pathName, SerializableBindingList<Veicoli> objectlist){}
public static void CreateHtml(SerializableBindingList<Veicoli> objectList, string pathName, string skeletonPathName = @".\www\index-skeleton.html"){}
```

### ConsoleUtilities
```csharp
public static void CreateTable(string tableName){}
public static void AddNewItem(string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmPercorsi, int price, int numAirbag, string saddleBrand){}
public static void ListTable(string tableName){}
public static void Update(string tableName, int id, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, int price, int numAirbag, string saddleBrand){}
public static void Delete(string tableName, int id){}
public static bool takeActualValue(string parameter, string tableName, int id){}
public static int ItemsCounter(string tableName){}
public static void DropTable(string tableName){}
```

--------------------------------

my Social Media | Links
------------- | ------------------------------------------------------------------
my Instagram: | [palumbo__valerio](https://www.instagram.com/palumbo__valerio/)
my Youtube Channel: | [RedX64](https://www.youtube.com/channel/UCWOLxDm6jrNPUvrkjsRmscg?view_as=subscriber)
my Website: | [valepaluseba.altervista.org](https://valepaluseba.altervista.org/)

you can contact me: v.palumbo.1004@vallauri.edu

>*By Palumbo Valerio Sebastiano*
