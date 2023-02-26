using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : FallingObject
{
    public float progressAmount;
    public float alertAmount;
    public override void Caught()
    {
        controller.UpdateProgress(progressAmount);
    }

    public override void Missed()
    {
        controller.UpdateAlert(alertAmount);
    }
}
