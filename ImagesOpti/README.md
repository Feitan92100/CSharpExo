# ImagesOpti

Petit utilitaire console pour optimiser et redimensionner des images en masse. 

Le script prend des images sources (jpg, png), les redimensionne en plusieurs formats (1080p, 720p, 480p) et les convertit en WebP. J'ai utilisé l'asynchrone et le multithreading (`Parallel.ForEachAsync`) pour accélérer le traitement.

## Prérequis
- .NET 10
- Le package `SixLabors.ImageSharp`

## Utilisation
1. Placez vos images dans le dossier `images/files`
2. Run.
3. Les images optimisées seront générées dans le sous-dossier `finito`.

## RESULT 

Temps SÉQUENTIEL SANS OPTI : 3794 ms
Temps SÉQUENTIEL AVEC OPTI : 1332 ms
