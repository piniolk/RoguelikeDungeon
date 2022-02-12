using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField] float health = 100;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float mana = 100;
    [SerializeField] float maxMana = 100;
    int magicMax = 0;

    GameManager gameManager;

    public Magic[] magicInv;

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

    void DamageTaken(float damage) {
        Debug.Log(damage + " damage Taken");
        health -= damage;
        gameManager.UpdateHealthNum(health);
        if (health <= 0) {
            Debug.Log("Dead");
            gameManager.DeathScreenOn();
        }
    }

    public bool HealthAdd(float heal) {
        if(health == maxHealth) {
            return false;
        }
        if(health + heal > maxHealth) {
            health = maxHealth;
        } else {
            health += heal;
        }
        gameManager.UpdateHealthNum(health);
        return true;
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

    public void AddMagicInfo(Magic newMagic) {
        magicInv[magicMax] = newMagic;
        magicMax++;
        magicInv[magicMax-1].setSelect(magicMax);
    }

    public bool CheckMagic(int num) {
        return (num) <= magicMax;
    }

    public int GetMagicMax() {
        return magicMax;
    }
}
