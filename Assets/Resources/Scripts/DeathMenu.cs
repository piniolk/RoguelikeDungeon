using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void TitleScreen() {
        gameManager.DeathScreenOff();
        GameObject[] gameObj = GameObject.FindGameObjectsWithTag("GameManager");
        Destroy(this.gameObject);
        SceneManager.LoadScene("Title");
    }
}
