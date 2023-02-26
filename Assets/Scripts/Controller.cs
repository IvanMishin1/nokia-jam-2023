using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    int level;

    float progress;
    public float progressGoal;
    public Image progressBar;

    float alert;
    public float alertGoal;
    public float alertPerSecond;
    public Image alertBar;

    float firewall;
    public float firewallMax;
    public Image firewallBar;
       

    public float timeScaleMin;
    public float timeScaleMax;
    public float timeScaleStep;
    public float timeScaleInitial;

    public Image plusImage;
    public Sprite plusPressed;
    public Sprite plusUnpressed;

    public Image minusImage;
    public Sprite minusPressed;
    public Sprite minusUnpressed;

    public Text text;

    public void Start()
    {
        NewLevel();

        Time.timeScale = timeScaleInitial;
    }

    public void NewLevel()
    {
        level++;
        text.enabled = true;
        text.text = "Level " + level;
        Invoke("DisableText", 3f);

        //Make all the bars empty when the game starts
        alert = 0;
        UpdateAlert(0);
        progress = 0;
        UpdateProgress(0);
        firewall = firewallMax;
        UpdateFirewall(0);

    }

    void DisableText()
    {
        text.enabled = false;
    }

    public void Update()
    {
        //Alert is increased over time, unaffected by the player changing the game speed.
        UpdateAlert(alertPerSecond * Time.unscaledDeltaTime);

        //The player can change the timescale. It is clamped within a minimum and maximum.
        if (Input.GetKeyDown("up") && Time.timeScale < timeScaleMax)
        {
            Time.timeScale += timeScaleStep;
            plusImage.sprite = plusPressed;
        }
        if (Input.GetKeyUp("up")) plusImage.sprite = plusUnpressed;

        if (Input.GetKeyDown("down") && Time.timeScale > timeScaleMin)
        {
            Time.timeScale -= timeScaleStep;
            minusImage.sprite = minusPressed;
        }
        if (Input.GetKeyUp("down")) minusImage.sprite = minusUnpressed;

        Time.timeScale = Mathf.Clamp(Time.timeScale, timeScaleMin, timeScaleMax);
    }
    public void UpdateProgress(float amount)    //Called by other objects when progress should be updated.
    {
        progress += amount;
        UpdateBar(progressBar, progress /progressGoal, true);

        if (progress >= progressGoal) NewLevel();
    }

    public void UpdateAlert(float amount)   //Called by other objects when alert should be updated.
    {
        alert += amount;
        UpdateBar(alertBar, alert / alertGoal, true);
    }

    public void UpdateFirewall(float amount)   //Called by other objects when alert should be updated.
    {
        firewall += amount;
        UpdateBar(firewallBar, firewall / firewallMax, false);
    }

    public void UpdateBar(Image bar, float fillAmount, bool floor)
    {
        float width = bar.rectTransform.rect.width;
        Debug.Log(width);
        if (floor) bar.fillAmount = Mathf.Floor(fillAmount * width) / width; // Make sure the bar only fills whole pixels
        else bar.fillAmount = Mathf.Ceil(fillAmount * width) / width;
    }


}
