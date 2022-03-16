using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour {
    private GameObject[] spawns;
    private GameObject roomEntered;
    [SerializeField] GameObject[] enemyPrefabs;
    private GameObject player;
    private RoomRandomizer roomRandomizer;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        roomRandomizer = this.gameObject.GetComponent<RoomRandomizer>();
    }

    public void SpawnEnemies() {
        KillAllEnemies();
        Debug.Log("Player: " + player.transform.position.x + " " + player.transform.position.z);
        int[] nums = roomRandomizer.CheckRoomPos(player.transform.position.x, player.transform.position.z);
        int x = nums[0];
        int z = nums[1];
        Debug.Log("Room 1: " + x + " " + z);
        GameObject room = roomRandomizer.GetRoom(x, z);
        Debug.Log("room coords 2: " + ":" + " x: " + room.transform.position.x + ", z: " + room.transform.position.z);
        GameObject[] spawns = room.GetComponent<Spawns>().GetSpawns();
        //for (int i = 0; i < Random.Range(1, 2); i++) {
        for (int i = 0; i < 1; i++) {
            Vector3 vecOriginal = spawns[Random.Range(0, spawns.Length - 1)].transform.position;
            Vector3 vec;
            Vector3 offset = room.transform.position;
            vec = vecOriginal + offset;
            //Vector3 vec = spawns[0].transform.localPosition;
            //Vector3 vec = transform.parent.parent.InverseTransformPoint(spawns[0].transform.position);
            vec.y = 4.34f;
            Debug.Log("spawns + room " + i + ":" + " x: " + vec.x + ", z: " + vec.z);
            Debug.Log("spawns " + i + ":" + " x: " + vecOriginal.x + ", z: " + vecOriginal.z);
            Debug.Log("room " + i + ":" + " x: " + offset.x + ", z: " + offset.z);
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)], vecOriginal, Quaternion.identity);
        }
    }

    private void KillAllEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }

}
