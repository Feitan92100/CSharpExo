using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

public class Dresseur : Personnage
{
    public List<Pokemon> Equipe { get; set; } = new List<Pokemon>();
    public Pokemon PokemonActif { get; set; }
}
