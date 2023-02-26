using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMovement : VirusEffect
{
    public Catcher catcher;
    public override void Infect()
    {
        catcher.mode = Catcher.Mode.reversed;
    }

    public override void Revert()
    {
        catcher.mode = Catcher.Mode.normal;
    }
}
