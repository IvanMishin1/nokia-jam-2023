using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFolder : FallingObject
{
    public float progressAmount;
    public float alertAmount;
    public override void Caught()
    {
        controller.UpdateProgress(progressAmount);
        controller.UpdateAlert(alertAmount);
    }
}
