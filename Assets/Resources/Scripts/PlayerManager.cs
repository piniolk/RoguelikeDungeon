using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public float health = 100;
    public float maxHealth = 100;
    public float mana = 100;
    public float maxMana = 100;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            DamageTaken(10);
        }
    }

    public void DamageTaken(float damage) {
        Debug.Log(damage + " damage Taken");
        health -= damage;
        gameManager.UpdateHealthNum(health);
        if (health <= 0) {
            Debug.Log("Dead");
            gameManager.DeathScreenOn();
        }
    }

    public void HealthAdd(float heal) {
        if(health + heal > maxHealth) {
            health = maxHealth;
        } else {
            health += heal;
        }
        gameManager.UpdateHealthNum(health);
    }

    public float GetHealth() {
        return health;
    }

    public float GetMana() {
        return mana;
    }

    public bool ManaUse(float amount) {
        if (mana - amount < 0) {
            Debug.Log("Not enough mana");
            return false;
        } else {
            mana -= amount;
            gameManager.UpdateManaNum(mana);
            return true;
        }
    }

    public void ManaAdd(float amount) {
        if (mana + amount > maxMana) {
            float temp = maxMana - mana;
            mana = maxMana;
        } else {
            mana += amount;
        }
        gameManager.UpdateManaNum(mana);
    }
}
