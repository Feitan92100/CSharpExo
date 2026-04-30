using System;
using System.IO;
using System.Linq;

Console.WriteLine("Quel est votre recherche ?");
string? recherche = Console.ReadLine();

if (!string.IsNullOrEmpty(recherche))
{
    var allAlbumsText = from line in File.ReadAllLines($@"{Directory.GetCurrentDirectory()}/Text/Albums.txt")
                        where line.Contains(recherche, StringComparison.InvariantCultureIgnoreCase)
                        select line;

    foreach (var line in allAlbumsText)
    {
        Console.WriteLine(line);
    }
}