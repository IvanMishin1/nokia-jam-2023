using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    int level;
    bool gameOver = false;

    public Spawner spawner;
    public Transform fallingStuffContainer;
    public Catcher catcher;
    public VirusHandler virusHandler;

    float progress;
    public float progressGoal;
    public float progressGoalIncrease;
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
    public bool timeScaleLocked;

    public Image plusImage;
    public Sprite plusPressed;
    public Sprite plusUnpressed;

    public Image minusImage;
    public Sprite minusPressed;
    public Sprite minusUnpressed;

    public Text text;

    public void Start()
    {
        Application.targetFrameRate = 15;

        NewLevel();
        //gameOver = true;
        //Time.timeScale = 0;
    }

    public void NewLevel()
    {
        level++;
        text.enabled = true;
        text.text = "Level " + level;
        Invoke("DisableText", 3f);
        Time.timeScale = timeScaleInitial;

        progressGoal += progressGoalIncrease;

        spawner.LevelUp();
        virusHandler.RevertAll();
        foreach(Transform transform in fallingStuffContainer)
        {
            Destroy(transform.gameObject);  //Destroy all the objects when a new level starts
        }

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
        if (gameOver)
        {
            if (Input.GetKeyDown("space"))
            {
                //Time.timeScale = timeScaleInitial;
                //level = 0;
                //NewLevel();
                //gameOver = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        else
        {
            //Alert is increased over time, unaffected by the player changing the game speed.
            UpdateAlert(alertPerSecond * Time.unscaledDeltaTime);

            //The player can change the timescale. It is clamped within a minimum and maximum.
            if (Input.GetKeyDown("up") && Time.timeScale < timeScaleMax && !timeScaleLocked)
            {
                Time.timeScale += timeScaleStep;
                plusImage.sprite = plusPressed;
            }
            if (Input.GetKeyUp("up")) plusImage.sprite = plusUnpressed;

            if (Input.GetKeyDown("down") && Time.timeScale > timeScaleMin && !timeScaleLocked)
            {
                Time.timeScale -= timeScaleStep;
                minusImage.sprite = minusPressed;
            }
            if (Input.GetKeyUp("down")) minusImage.sprite = minusUnpressed;

            Time.timeScale = Mathf.Clamp(Time.timeScale, timeScaleMin, timeScaleMax);
        }

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
        if (alert >= alertGoal) GameOver();
    }

    public void UpdateFirewall(float amount)   //Called by other objects when alert should be updated.
    {
        firewall += amount;
        if (firewall <= 0) Virus();
        UpdateBar(firewallBar, firewall / firewallMax, false);

    }

    public void UpdateBar(Image bar, float fillAmount, bool floor)
    {
        float width = bar.rectTransform.rect.width;
        if (floor) bar.fillAmount = Mathf.Floor(fillAmount * width) / width; // Make sure the bar only fills whole pixels
        else bar.fillAmount = Mathf.Ceil(fillAmount * width) / width;
    }

    void Virus()
    {
        firewall += firewallMax;
        virusHandler.Infect();

        text.enabled = true;
        text.text = "VIRUS";
        Invoke("DisableText", 2f);
    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        text.enabled = true;
        text.text = "Game Over";
    }
}
