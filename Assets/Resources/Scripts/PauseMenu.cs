using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;

    public void Unpause() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void GoToTitle() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
