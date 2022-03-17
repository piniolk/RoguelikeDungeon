using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour {
    private float health = 25f;


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (GameObject.FindObjectOfType<PlayerManager>().HealthAdd(health)) {
                Destroy(gameObject);
            }
        }
    }
}
