using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour {
    public GameObject ControlsPanel;
    public GameObject SettingsPanel;
    public GameObject TitlePanel;

    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void Controls() {
        TitlePanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void ControlsClose() {
        ControlsPanel.SetActive(false);
        TitlePanel.SetActive(true);
    }

    public void Settings() {
        TitlePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void SettingsClose() {
        SettingsPanel.SetActive(false);
        TitlePanel.SetActive(true);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
