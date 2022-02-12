using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMagic : MonoBehaviour {

    PlayerManager playerManager;
    GameManager gameManager;
    [SerializeField] Magic magicInfo;

    void Start() {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            playerManager.AddMagicInfo(magicInfo);
            gameManager.UpdateImg();
            Destroy(gameObject);
        }
    }
}
