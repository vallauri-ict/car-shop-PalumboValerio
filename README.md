# CarShop 

A carshop menagement software

--------------------------------
*Project version: __7.0.0__*

*Project specifics:*
1. Windows Forms Project
	- Add, Delete, Modify and Save the vehicles datas;
	- Create a Word document with vehicles datas;
	- Create an Excel document with vehicles datas;
	- Create html with vehicles datas.
2. Console Project
	- Create two tables in an Access project;
	- You can insert in the tables more personal datas;
	- You can visualize the tables in console;
	- You can modify a data in the tables;
	- You can remove datas in the tables;
	- You can delete the tables;
	- You can create a backup of the database;
	- You can restore the backup of the database.

--------------------------------

*List of public methods:*
### ListUtilities
```csharp
public void OpenDBInList(SerializableBindingList<Vehicles> list, string connStr){}
 public void UpdateDb(SerializableBindingList<Vehicles> list, string connStr){}
public static void CreateHtml(SerializableBindingList<Veicoli> objectList, string pathName, string skeletonPathName = @".\www\index-skeleton.html"){}
```

### DBUtilities
```csharp
public static void CreateTable(string tableName){}
public static void AddNewItem(string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmPercorsi, int price, int numAirbag, string saddleBrand){}
public static void ListTable(string tableName){}
public static void Update(string tableName, int id, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, int price, int numAirbag, string saddleBrand){}
public static void Delete(string tableName, int id){}
public static bool takeActualValue(string parameter, string tableName, int id){}
public static int ItemsCounter(string tableName){}
public static void DropTable(string tableName){}
public void CreateBackup(string dbFilePath){}
public void RestoresBackup(string dbFilePath){}
```

### OpenXMLWordUtilities
```csharp
public void InsertPicture(WordprocessingDocument wordprocessingDocument, string fileName){}
public RunProperties AddStyle(MainDocumentPart mainPart, bool isBold = false, bool isItalic = false, bool isUnderline = false, bool isOnlyRun = false, string styleId = "00", string styleName = "Default", string fontName = "Calibri", int fontSize = 12, string rgbColor = "000000", UnderlineValues underline = UnderlineValues.Single){}
public Paragraph CreateParagraphWithStyle(string styleId, JustificationValues justification = JustificationValues.Left){}
public void AddTextToParagraph(Paragraph paragraph, string content, SpaceProcessingModeValues space = SpaceProcessingModeValues.Default, RunProperties rpr = null){}
public void CreateBulletNumberingPart(MainDocumentPart mainPart, string bulletChar = "-"){}
public void CreateBulletOrNumberedList(int indentLeft, int indentHanging, List<Paragraph> paragraphs, string[] texts, bool isBullet = true){}
public Table createTable(MainDocumentPart mainPart, bool[] bolds, bool[] italics, bool[] underlines, string[] texts, JustificationValues[] justifications, int rows, int cell, string rgbColor = "000000", BorderValues borderValues = BorderValues.Thick){}
```

### OpenXMLExcelUtilities
```csharp
public void CreatePartsForExcel(SpreadsheetDocument document, SerializableBindingList<Vehicles> data){}
```

### GeneralUtilities
```csharp
public string SelectPath(FolderBrowserDialog fbd){}
public string OutputFileName(string OutputFileDirectory, string fileExtension){}
```

### ErrorProviderUtilities
```csharp
public void setError(ErrorProvider error, Control control, string msg){}
public void resetError(ErrorProvider error, Control control){}
```

--------------------------------

my Social Media | Links
------------- | ------------------------------------------------------------------
my Instagram: | [palumbo__valerio](https://www.instagram.com/palumbo__valerio/)
my Youtube Channel: | [RedX64](https://www.youtube.com/channel/UCWOLxDm6jrNPUvrkjsRmscg?view_as=subscriber)
my Website: | [valepaluseba.altervista.org](https://valepaluseba.altervista.org/)

you can contact me: v.palumbo.1004@vallauri.edu

>*By Palumbo Valerio Sebastiano*
