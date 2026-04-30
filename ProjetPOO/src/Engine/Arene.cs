using System;
using System.Collections.Generic;
using System.Text;

public class Arene
{
    // L'Arène stocke l'état global de la session
    public Dresseur Joueur { get; set; }
    public DresseurIA Adversaire { get; set; }
    public Arbitre Arbitre { get; set; }
}