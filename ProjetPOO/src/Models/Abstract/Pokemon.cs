using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

public abstract class Pokemon
{
    public string Nom { get; set; }
    public int PVActuels { get; set; }
    public int PVMax { get; set; }
    public Element TypePrincipal { get; set; }
    public List<Attaque> ListeAttaques { get; set; } = new List<Attaque>();
    public bool EstKO => PVActuels <= 0;
}
