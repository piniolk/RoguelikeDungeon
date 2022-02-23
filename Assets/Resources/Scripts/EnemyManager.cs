using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public float health = 50;
    public float damage = 10;
    public Slider healthBar;

    public GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void LateUpdate() {
        //GetComponent<NavMeshAgent>().destination = player.transform.position;
    }

    public void DamageTaken(float damage) {
        health -= damage;
        healthBar.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
