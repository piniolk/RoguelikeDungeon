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
        int[] nums = roomRandomizer.CheckRoomPos(player.transform.position.x, player.transform.position.z);
        int x = nums[0];
        int z = nums[1];
        GameObject room = roomRandomizer.GetRoom(x, z);
        GameObject[] spawns = room.GetComponent<Spawns>().GetSpawns();
        GameObject enemy;
        for (int i = 0; i < Random.Range(2,5); i++) {
            Vector3 vecOriginal = spawns[Random.Range(0, spawns.Length - 1)].transform.position;
            Vector3 vec;
            Vector3 offset = room.transform.position;
            vec = vecOriginal + offset;
            vec.y = 4.34f;
            enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length - 1)], vecOriginal, Quaternion.identity) as GameObject;
        }
    }

    private void KillAllEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }

}
