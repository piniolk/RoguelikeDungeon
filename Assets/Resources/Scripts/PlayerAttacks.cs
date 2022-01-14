using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {
    public float bluntDamage = 10;
    public float bluntRange = 10;
    public float magicDamage = 25;
    public float magicRange = 25;
    public float manaConsumed = 10;
    public int magicSelect = 1;
    PlayerManager playerManager;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
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
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            magicSelect = 1;
            gameManager.UpdateInv(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            magicSelect = 2;
            gameManager.UpdateInv(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            magicSelect = 3;
            gameManager.UpdateInv(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            magicSelect = 4;
            gameManager.UpdateInv(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            magicSelect = 5;
            gameManager.UpdateInv(5);
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


}
