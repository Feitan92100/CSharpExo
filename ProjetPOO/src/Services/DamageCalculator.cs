using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Generic;

public class DamageCalculator
{
    // Table de correspondance associant le couple (Type Attaque, Type Défenseur)
    // à son multiplicateur de dégâts, pour éviter le gros de 300 lignes (switch/if).
    private Dictionary<(Element, Element), float> _efficacite;
}