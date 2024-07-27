using UnityEngine;

public class SettingsMenuScript : MonoBehaviour
{
    public GameObject settingsPanel;

    public void CloseSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
}
