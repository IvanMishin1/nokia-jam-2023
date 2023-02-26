using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : FallingObject
{
    public float firewallAmount;
    public override void Caught()
    {
        controller.UpdateFirewall(firewallAmount);
    }
}
