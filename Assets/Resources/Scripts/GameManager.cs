using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI healthNum;
    public TextMeshProUGUI manaNum;
    public TextMeshProUGUI levelNum;
    public GameObject deathScreen;
    public Image[] invPanels;
    public Image[] imgPanels;
    public Image[] cooldownPanels;
    public TextMeshProUGUI[] manaNums;
    public Slider healthBar;
    public Slider manaBar;
    Color defaultInv;
    Color selectInv;
    float healthN;
    float manaN;
    GameObject player;
    PlayerManager playerManager;
    RoomRandomizer roomRandomizer;
    ItemSpawns itemSpawns;
    public int levelNumInt;
    private float scaleMax = 1.3f;

    // Start is called before the first frame update
    void Start() {
        roomRandomizer = GetComponent<RoomRandomizer>();
        roomRandomizer.LoadLevel();
        levelNum = GameObject.FindGameObjectWithTag("LevelNum").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerManager = FindObjectOfType<PlayerManager>();
        healthN = playerManager.GetHealth();
        manaN = playerManager.GetMana();
        selectInv = new Color32(115, 150, 164, 255);
        defaultInv = new Color32(39, 61, 70, 255);
        healthBar.maxValue = healthN;
        healthBar.value = healthN;
        manaBar.maxValue = manaN;
        manaBar.value = manaN;
        itemSpawns = this.GetComponent<ItemSpawns>();
        itemSpawns.SpawnMagicItems();
        itemSpawns.SpawnPotions();
    }

    private void Awake() {
        GameObject[] gameObj = GameObject.FindGameObjectsWithTag("GameManager");
        if (gameObj.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.P)) {
            NextLevel();
        }
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

    public void UpdateImg() {
        Magic magic = playerManager.magicInv[playerManager.GetMagicMax() - 1];
        Sprite newSprite = magic.GetImage();
        imgPanels[playerManager.GetMagicMax() - 1].GetComponent<Image>().sprite = newSprite;
        manaNums[playerManager.GetMagicMax() - 1].text = magic.GetManaCost().ToString();
    }

    public void Stuff(int select) {
        StartCoroutine(DoCooldownImg(select));
    }

    public IEnumerator DoCooldownImg(int select) {
        float scaleNum = scaleMax;
        Vector3 scale = new Vector3(scaleNum, scaleNum, scaleNum);
        cooldownPanels[select - 1].transform.localScale = scale;
        float percentage = 1f;
        float seconds = playerManager.magicInv[select - 1].GetCooldownMax();
        playerManager.magicInv[select - 1].SetCooldownCurrent(playerManager.magicInv[select - 1].GetCooldownMax());
        float cooldown = playerManager.magicInv[select - 1].GetCooldownCurrent();
        seconds *= .1f;
        while (percentage >= 0f) {
            scaleNum -= .1f;
            percentage -= .1f;
            cooldown -= playerManager.magicInv[select - 1].GetCooldownMax() * .1f;
            playerManager.magicInv[select - 1].SetCooldownCurrent(cooldown);
            scale = new Vector3(scaleNum, scaleNum, scaleNum);
            yield return new WaitForSeconds(seconds * Time.deltaTime);
            cooldownPanels[select - 1].transform.localScale = scale;
        }
        cooldownPanels[select - 1].transform.localScale = new Vector3(0, 0, 0);
        playerManager.magicInv[select - 1].SetCooldownCurrent(0);
    }

    public void NextLevel() {
        //levelNumInt++;
        //levelNum.text = levelNumInt.ToString();
        StartCoroutine(WaitForSceneLoad());
    }

    private IEnumerator WaitForSceneLoad() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
