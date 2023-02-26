using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMovement : VirusEffect
{
    public Catcher catcher;
    public override void Infect()
    {
        catcher.reversed = true;
    }

    public override void Revert()
    {
        catcher.reversed = false;
    }
}
