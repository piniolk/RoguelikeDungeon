using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField] float health = 100;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float mana = 100;
    [SerializeField] float maxMana = 100;
    int magicMax = 0;
    AudioSource audioSource;
    public AudioClip audioHurt;
    public AudioClip audioMagicPickUp;
    public AudioClip audioPotionPickUp;
    private Animator playerAnimator;

    GameManager gameManager;

    PlayerAttacks playerAttacks;

    public Magic[] magicInv;

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        playerAttacks = GetComponent<PlayerAttacks>();
        playerAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    } 

    public void Hit(float damage) {
        DamageTaken(damage);
        playerAnimator.SetBool("isHit", true);
        playerAnimator.SetBool("isHit", false);
    }

    void DamageTaken(float damage) {
        Debug.Log(damage + " damage Taken");
        health -= damage;
        audioSource.clip = audioHurt;
        audioSource.Play();
        gameManager.UpdateHealthNum(health);
        if (health <= 0) {

            playerAnimator.SetTrigger("isDead");
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
        audioSource.clip = audioPotionPickUp;
        audioSource.Play();
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

    public bool ManaAdd(float amount) {
        if (mana >= maxMana) {
            return false;
        }
        else if (mana + amount > maxMana) {
            float temp = maxMana - mana;
            mana = maxMana;
        } else {
            mana += amount;
        }
        gameManager.UpdateManaNum(mana);
        audioSource.clip = audioPotionPickUp;
        audioSource.Play();
        return true;
    }

    public void AddMagicInfo(Magic newMagic) {
        audioSource.clip = audioMagicPickUp;
        audioSource.Play();
        magicInv[magicMax] = newMagic;
        magicMax++;
        magicInv[magicMax-1].SetSelect(magicMax);
        if (magicMax == 1) {
            playerAttacks.UpdateCurrentMagic();
        }
    }

    public bool CheckMagic(int num) {
        return (num) <= magicMax;
    }

    public int GetMagicMax() {
        return magicMax;
    }
}
