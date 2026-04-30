using System.Diagnostics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

// Dossier source des images
var path = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "../../../images/files"));
var extensions = new[] { "*.jpg", "*.jpeg", "*.png" };

// Résolutions
var resolutions = new[] { 1080, 720, 480 };

// Dossier de sortie
var sortieDir = Directory.CreateDirectory(Path.Combine(path.FullName, "finito"));

// Encodeur WebP
var encodeur = new WebpEncoder { Quality = 80 };

// Récupération des images
var allImages = extensions.SelectMany(ext => path.GetFiles(ext));

var sw = Stopwatch.StartNew();
Parallel.ForEach(allImages, imageFile =>
{
    using var image = Image.Load(imageFile.FullName);

    foreach (var taille in resolutions)
    {
      using var resized = image.Clone(ctx => ctx.Resize(new ResizeOptions
        {
            Mode = ResizeMode.Max,
            Size = new Size(0, taille)
        }));

        var outputFileName = $"{Path.GetFileNameWithoutExtension(imageFile.Name)}_{taille}p.webp";
        var outputPath = Path.Combine(sortieDir.FullName, outputFileName);

        resized.Save(outputPath, encodeur);
        Console.WriteLine($"Généré : {outputFileName}");
    }
});


sw.Stop();
Console.WriteLine($"Temps SÉQUENTIEL AVEC OPTI : {sw.ElapsedMilliseconds} ms");
