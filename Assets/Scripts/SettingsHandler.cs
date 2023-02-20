using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public Toggle juicyModeToggle;

    private void Start()
    {
        // Retrieve the saved toggle state from PlayerPrefs on start
        juicyModeToggle.isOn = (PlayerPrefs.GetInt("juicyMode", 0) == 1);

        // Subscribe to the onValueChanged event to save toggle state when it changes
        juicyModeToggle.onValueChanged.AddListener(SyncJuicyMode);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the onValueChanged event when the script is destroyed
        juicyModeToggle.onValueChanged.RemoveListener(SyncJuicyMode);
    }

    public void SyncJuicyMode(bool isOn)
    {
        // Save the toggle state to PlayerPrefs
        PlayerPrefs.SetInt("juicyMode", isOn ? 1 : 0);
    }
}