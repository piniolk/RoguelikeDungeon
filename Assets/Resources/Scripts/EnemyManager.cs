using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public float health = 50;
    public float damage = 10;
    float range = 5;
    public Slider healthBar;
    [SerializeField] GameObject player;
    private Vector3 targetVec;
    [SerializeField] private float speed = 15f;

    // Start is called before the first frame update
    void Start() {
        healthBar.maxValue = health;
        healthBar.value = health;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        targetVec = player.transform.position;

        Movement();
    }

    public void DamageTaken(float damage) {
        health -= damage;
        healthBar.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void Movement() {
        Vector3 move = targetVec - this.transform.position;
        move.y = 0;
        move.Normalize();
        //this.transform.Translate((move.x * speed * Time.deltaTime), 0, (move.z * speed * Time.deltaTime));
        transform.LookAt(player.transform.position, Vector3.up);
        this.transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void Wander() {
        // pick random direction
        Vector3 direction = new Vector3(Random.Range(-5,5), 0, Random.Range(-5, 5));
        // keep walking
        //this.transform.Translate((direction.x * speed * Time.deltaTime), 0, (direction.z * speed * Time.deltaTime));
        transform.LookAt(player.transform.position, Vector3.up);
    }
}
