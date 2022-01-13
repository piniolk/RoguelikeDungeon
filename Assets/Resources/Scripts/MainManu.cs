using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour {
    public GameObject ControlsPanel;
    public GameObject SettingsPanel;

    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Controls() {
        ControlsPanel.SetActive(true);
    }

    public void ControlsClose() {
        ControlsPanel.SetActive(false);
    }

    public void Settings() {
        SettingsPanel.SetActive(true);
    }

    public void SettingsClose() {
        SettingsPanel.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
