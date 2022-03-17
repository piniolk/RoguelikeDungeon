using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMana : MonoBehaviour {
    private float mana = 25f;


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (GameObject.FindObjectOfType<PlayerManager>().ManaAdd(mana)) {
                Destroy(gameObject);
            }
        }
    }
}
