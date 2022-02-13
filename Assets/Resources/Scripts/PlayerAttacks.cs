using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {
    [SerializeField] float bluntDamage = 10;
    [SerializeField] float bluntRange = 10;
    [SerializeField] float magicDamage;
    [SerializeField] float magicRange;
    [SerializeField] float manaConsumed;
    public int magicSelect = 1;
    PlayerManager playerManager;
    GameObject player;
    GameManager gameManager;
    [SerializeField] GameObject particles;
    GameObject particlesMagic;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
        playerManager = GetComponent<PlayerManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Attack(bluntDamage, bluntRange); 
            GameObject probaParticleClone = Instantiate(particles, player.transform.position, player.transform.rotation) as GameObject;
            Destroy(probaParticleClone, 3);
        }
        if (Input.GetButtonDown("Fire2") && playerManager.CheckMagic(magicSelect)) {
            if (playerManager.ManaUse(manaConsumed)) {
                Attack(magicDamage, magicRange);
                GameObject probaParticleClone = Instantiate(particlesMagic, player.transform.position, player.transform.rotation) as GameObject;
                Destroy(probaParticleClone, 3);
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
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null) {
                enemyManager.DamageTaken(damage);
            }
        }
    }

    public void UpdateCurrentMagic() {
        Magic newMagic = playerManager.magicInv[magicSelect - 1];
        magicDamage = newMagic.GetDamage();
        magicRange = newMagic.GetRange();
        manaConsumed = newMagic.GetManaCost();
        particlesMagic = newMagic.GetParticles();
    }

}
