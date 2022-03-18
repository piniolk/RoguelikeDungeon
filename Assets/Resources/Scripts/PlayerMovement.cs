using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 20f;
    float walkSpeed = 20f;
    float runSpeed = 30f;
    public float rotationSpeed;
    public CharacterController player;
    RoomRandomizer roomRandomizer;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        roomRandomizer = FindObjectOfType<GameManager>().GetComponent<RoomRandomizer>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameManager.GetComponent<PauseMenu>().Pause();
        } 

        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
        } else {
            speed = walkSpeed;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        player.Move(movement * speed * Time.deltaTime);

        Vector3 mousePos = Input.mousePosition;
        //Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 50));
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3( mousePos.x, mousePos.y, 50));
        transform.LookAt(mouseWorld, Vector3.up);

    }

    private void OnCollisionEnter(Collision collision) {
        float x = player.GetComponent<Transform>().position.x;
        float y = player.GetComponent<Transform>().position.y;
        float z = player.GetComponent<Transform>().position.z;

        if (collision.gameObject.CompareTag("LeftDoor") && roomRandomizer.CheckValidRoom(x, z, "left")) {
            player.GetComponent<Transform>().SetPositionAndRotation(new Vector3 (x - 15, y, z), Quaternion.identity);
            FindObjectOfType<GameManager>().GetComponent<EnemySpawns>().SpawnEnemies();
        }
        if (collision.gameObject.CompareTag("RightDoor") && roomRandomizer.CheckValidRoom(x, z, "right")) {
            player.GetComponent<Transform>().SetPositionAndRotation(new Vector3 (x + 15, y, z), Quaternion.identity);
            FindObjectOfType<GameManager>().GetComponent<EnemySpawns>().SpawnEnemies();
        }
        if (collision.gameObject.CompareTag("FDoor") && roomRandomizer.CheckValidRoom(x, z, "f")) {
            player.GetComponent<Transform>().SetPositionAndRotation(new Vector3 (x, y, z + 15), Quaternion.identity);
            FindObjectOfType<GameManager>().GetComponent<EnemySpawns>().SpawnEnemies();
        }
        if (collision.gameObject.CompareTag("BDoor") && roomRandomizer.CheckValidRoom(x, z, "b")) {
            player.GetComponent<Transform>().SetPositionAndRotation(new Vector3 (x, y, z - 15), Quaternion.identity);
            FindObjectOfType<GameManager>().GetComponent<EnemySpawns>().SpawnEnemies();
        }
    }

}
