using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Vector3 speed;
    public float rotationSpeed;
    private Rigidbody player;

    // Start is called before the first frame update
    void Start() {
        this.player = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(this.speed.x * inputX, 0, this.speed.z * inputZ);

        transform.Translate(movement * Time.deltaTime);

        if (movement != Vector3.zero) {
            //Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            //transform.forward = movement;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Dead");
            Destroy(this);
        }
    }
}
