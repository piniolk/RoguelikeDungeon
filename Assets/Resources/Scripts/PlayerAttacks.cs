using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {
    [SerializeField] float bluntDamage = 10;
    [SerializeField] float bluntRange = 10;
    [SerializeField] float magicDamage = 25;
    [SerializeField] float magicRange = 25;
    [SerializeField] float manaConsumed = 10;
    public int magicSelect = 1;
    PlayerManager playerManager;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Attack(bluntDamage, bluntRange);
        }
        if (Input.GetButtonDown("Fire2")) {
            playerManager = GetComponent<PlayerManager>();
            if (playerManager.ManaUse(manaConsumed)) {
                Attack(magicDamage, magicRange);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerManager.CheckMagic(1)) {
            magicSelect = 1;
            gameManager.UpdateInv(1); 
            UpdateCurrentMagic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerManager.CheckMagic(2)) {
            magicSelect = 2;
            gameManager.UpdateInv(2);
            UpdateCurrentMagic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && playerManager.CheckMagic(3)) {
            magicSelect = 3;
            gameManager.UpdateInv(3);
            UpdateCurrentMagic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && playerManager.CheckMagic(4)) {
            magicSelect = 4;
            gameManager.UpdateInv(4);
            UpdateCurrentMagic();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && playerManager.CheckMagic(5)) {
            magicSelect = 5;
            gameManager.UpdateInv(5);
            UpdateCurrentMagic();
        }
    }

    void Attack(float damage, float range) {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, range)) {
            Debug.Log("hit for " + damage);

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null) {
                enemyManager.DamageTaken(damage);
            }
        }
    }

    void UpdateCurrentMagic() {
        Magic newMagic = playerManager.magicInv[magicSelect - 1];
        magicDamage = newMagic.getDamage();
        magicRange = newMagic.getRange();
        manaConsumed = newMagic.getManaCost();
    }

}
