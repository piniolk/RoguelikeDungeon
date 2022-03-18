using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
    public float health = 50;
    public float damage = 10;
    public Slider healthBar;
    [SerializeField] GameObject player;
    private Vector3 targetVec;
    [SerializeField] private float speed = 15f;

    private Animator enemyAnimator;
    private bool playerInReach;
    private float attackDelayTimer;
    private float attackAnimStartDelay = .2f;
    private float delayBetweenAttacks = 3f;

    // Start is called before the first frame update
    void Start() {
        attackDelayTimer = 0f;
        healthBar.maxValue = health;
        healthBar.value = health;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        targetVec = player.transform.position;

        Movement();

        if (GetComponent<Rigidbody>().velocity.magnitude > 1) {
            enemyAnimator.SetBool("isMoving", true);
        } else {
            enemyAnimator.SetBool("isMoving", false);
        }
    }

    public void DamageTaken(float damage) {
        health -= damage;
        healthBar.value = health;
        if (health <= 0) {
            enemyAnimator.SetTrigger("isDead");
            Destroy(gameObject, 5f);
            speed = 0;
            Destroy(GetComponent<EnemyManager>());
            Destroy(GetComponent<CapsuleCollider>());
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

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject == player) {
            playerInReach = true;
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (playerInReach) {
            attackDelayTimer += Time.deltaTime;
        }

        if (attackDelayTimer >= delayBetweenAttacks - attackAnimStartDelay && attackDelayTimer <= delayBetweenAttacks && playerInReach) {
            enemyAnimator.SetTrigger("isAttacking");
        }

        if (attackDelayTimer >= delayBetweenAttacks && playerInReach) {
            player.GetComponent<PlayerManager>().Hit(damage);
            attackDelayTimer = 0;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject == player) {
            playerInReach = false;
            attackDelayTimer = 0;
        }
    }
}
