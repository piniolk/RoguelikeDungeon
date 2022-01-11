using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 20f;
    public float rotationSpeed;
    public CharacterController player;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);

        player.Move(movement * speed * Time.deltaTime);

        Vector3 mousePos = Input.mousePosition;
        //Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 50));
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(new Vector3( mousePos.x, mousePos.y, 50));
        transform.LookAt(mouseWorld, Vector3.up);

    }

}
