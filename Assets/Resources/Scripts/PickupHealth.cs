using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (GameObject.FindObjectOfType<PlayerManager>().HealthAdd(25)) {
                Destroy(gameObject);
            }
        }
    }
}
