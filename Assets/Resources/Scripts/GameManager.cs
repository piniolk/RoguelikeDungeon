using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI healthNum;
    public TextMeshProUGUI manaNum;
    public GameObject deathScreen;
    public Image[] invPanels;
    public Slider healthBar;
    public Slider manaBar;
    Color defaultInv;
    Color selectInv;
    float healthN;
    float manaN;
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start() {
        playerManager = FindObjectOfType<PlayerManager>();
        healthN = playerManager.GetHealth();
        manaN = playerManager.GetMana();
        selectInv = new Color32(115, 150, 164, 255);
        defaultInv = new Color32(39, 61, 70, 255);
        healthBar.maxValue = healthN;
        healthBar.value = healthN;
        manaBar.maxValue = manaN;
        manaBar.value = manaN;
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateHealthNum(float num) {
        healthNum.text = num.ToString();
        healthBar.value = num;
    }

    public void UpdateManaNum(float num) {
        manaNum.text = num.ToString();
        manaBar.value = num;
    }

    public void DeathScreenOn() {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }

    public void DeathScreenOff() {
        Time.timeScale = 1;
        deathScreen.SetActive(true);
    }

    public void UpdateInv(int select) {
        for (int i = 0; i < invPanels.Length; i++) {
            //invPanels[i] = GetComponent<Image>();
            invPanels[i].color = defaultInv;
        }
        //invPanels[select] = GetComponent<Image>();
        invPanels[select - 1].color = selectInv;
    }
}
