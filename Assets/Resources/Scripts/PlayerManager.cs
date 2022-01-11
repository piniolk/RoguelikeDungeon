using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    public int health = 100;
    public int maxHealth = 100;
    public int mana = 100;
    public int maxMana = 100;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            DamageTaken(10);
        }
    }

    public void DamageTaken(int damage) {
        health -= damage;
        if(health == 0) {
            Debug.Log("Dead");
            SceneManager.LoadScene(0);
        }
    }

    public void HealthAdd(int heal) {
        if(health + heal > maxHealth) {
            health = maxHealth;
        } else {
            health += heal;
        }
    }

    public bool ManaUse(int amount) {
        if (mana - amount < 0) {
            Debug.Log("Not enough mana");
            return false;
        } else {
            mana -= amount;
            return true;
        }
    }

    public void ManaAdd(int amount) {
        if (mana + amount > maxMana) {
            mana = maxMana;
        } else {
            mana += amount;
        }
    }
}
