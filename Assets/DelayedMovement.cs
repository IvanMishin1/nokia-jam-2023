using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedMovement : VirusEffect
{
    public Catcher catcher;
    public override void Infect()
    {
        catcher.delayed = true;
    }

    public override void Revert()
    {
        catcher.delayed = false;
    }
}
