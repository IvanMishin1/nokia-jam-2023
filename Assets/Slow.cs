using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : VirusEffect
{
    public Catcher catcher;
    public override void Infect()
    {
        catcher.slowed = true;
    }

    public override void Revert()
    {
        catcher.slowed = false;
    }
}
