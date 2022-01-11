using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {
    public int bluntDamage = 10;
    public int bluntRange = 10;
    public int magicDamage = 25;
    public int magicRange = 25;
    public int manaConsumed = 10;
    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start() {
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
    }

    void Attack(int damage, int range) {
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
