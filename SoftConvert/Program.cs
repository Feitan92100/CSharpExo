using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


var myJsonObject = JObject.Parse(File.ReadAllText($@"{Directory.GetCurrentDirectory()}\..\..\..\..\DataSources\Json\Employees.json"));

var jsonArray = (JArray)myJsonObject.Properties().First(p => p.Value is JArray).Value;

while (true) 
{
    Console.WriteLine("Quel est votre recherche?");
    string recherche = Console.ReadLine();

    // recherche et tri
    var searchResult = from JObject item in jsonArray
                       where item.Properties().Any(p => p.Value.ToString().Contains(recherche, StringComparison.InvariantCultureIgnoreCase))
                       orderby item.Properties().First().Value.ToString()
                       select item;

    // prévisualisation 
    foreach (var item in searchResult)
    {
        Console.WriteLine(string.Join(" - ", item.Properties().Select(p => $"{p.Name}:{p.Value}")));
    }

    Console.WriteLine("Voulez-vous exporter ces résultats en XML ? (o/n)");
    if (Console.ReadLine().ToLower() == "o")
    {
        var champsDisponibles = searchResult.FirstOrDefault()?.Properties().Select(p => p.Name).ToList();
        var champsAExporter = new List<string>();

        foreach (var champ in champsDisponibles)
        {
            Console.WriteLine($"Exporter '{champ}' ? (o/n)");
            if (Console.ReadLine().ToLower() == "o")
            {
                champsAExporter.Add(champ);
            }
        }

        // export
        XElement xmlExport = new XElement("Resultats",
            from JObject item in searchResult
            select new XElement("Item",
                from champ in champsAExporter
                select new XElement(champ, (string)item[champ])
            )
        );
                
        string cheminExport = $@"{Directory.GetCurrentDirectory()}\..\..\..\ExportGenerique.xml";
        xmlExport.Save(cheminExport);
        Console.WriteLine($"Export réussi ! Fichier enregistré sous : {cheminExport}");
    }
}