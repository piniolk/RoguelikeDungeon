using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour {
    [SerializeField] GameObject[] spawns;
    private GameObject roomEntered;
    [SerializeField] GameObject[] enemyPrefabs;
    private GameObject player;
    private RoomRandomizer roomRandomizer;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        roomRandomizer = this.gameObject.GetComponent<RoomRandomizer>();
    }

    public GameObject[] GetSpawns() {
        return spawns;
    }

    public void SpawnEnemies() {
        KillAllEnemies();
        int[] nums = roomRandomizer.CheckRoomPos(player.transform.position.x, player.transform.position.z);
        int x = nums[0];
        int z = nums[1];
        GameObject room = roomRandomizer.GetRoom(x, z);
        GameObject[] spawns = room.GetComponent<Spawns>().GetSpawns();
        for (int i = 0; i < Random.Range(0, 5); i++) {
            //Vector3 vec = spawns[Random.Range(0, spawns.Length - 1)].transform.localPosition;
            //Vector3 vec = spawns[0].transform.localPosition;
            Vector3 vec = transform.parent.parent.InverseTransformPoint(spawns[0].transform.position);
            vec.y = 4.34f;
            Debug.Log("i: " + i + ", x: " + vec.x + ", z: " + vec.z);
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)], vec, Quaternion.identity);
        }
    }

    private void KillAllEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
