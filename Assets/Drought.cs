using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drought : VirusEffect
{
    public Controller controller;
    public override void Infect()
    {
        controller.timeScaleLocked = true;
        Time.timeScale = controller.timeScaleMin;
    }

    public override void Revert()
    {
        controller.timeScaleLocked = false;
        Time.timeScale = controller.timeScaleInitial;
    }
}

