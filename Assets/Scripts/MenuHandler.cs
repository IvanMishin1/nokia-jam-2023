using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void Menu() // Switch to the MainMenu Scene
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play() // Switch to the Game Scene
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void Settings() // Switch to the Settings Scene
    {
        SceneManager.LoadScene("SettingsMenu");
    }
}