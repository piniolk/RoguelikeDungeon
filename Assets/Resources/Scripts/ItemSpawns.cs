using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawns : MonoBehaviour {
    private GameObject[] spawns;
    private GameObject roomEntered;
    [SerializeField] GameObject[] magicsPrefabs;
    [SerializeField] GameObject healthPotion;
    [SerializeField] GameObject manaPotion;
    private GameObject player;
    private RoomRandomizer roomRandomizer;
    private int potsMin = 3;
    private int potsMax = 6;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        roomRandomizer = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoomRandomizer>();
    }

    public void SpawnMagicItems() {
        //loop through all magic
        int count = magicsPrefabs.Length;
        for (int i = 0; i < count; i++) {
            //get spawns from room
            GameObject room = roomRandomizer.GetRoom(Random.Range(0, roomRandomizer.GetRoomLayoutWidth()-1), Random.Range(0, roomRandomizer.GetRoomLayoutHeight() - 1));
            GameObject[] spawns = room.GetComponent<Spawns>().GetSpawns();

            //pick random spawn
            Vector3 location = spawns[Random.Range(0, spawns.Length-1)].transform.position;
            location.y = 3.5f;
            //instaniate magic
            GameObject obj = Instantiate(magicsPrefabs[i], location, Quaternion.identity) as GameObject;
        }
    }

    public void SpawnPotions() {
        GameObject obj;
        int j = Random.Range(potsMin, potsMax);
        Quaternion rot = Quaternion.Euler(90, 0, 0);
        for (int i = 0; i < j; i++) {
            //get spawns from room
            GameObject room = roomRandomizer.GetRoom(Random.Range(0, roomRandomizer.GetRoomLayoutWidth() - 1), Random.Range(0, roomRandomizer.GetRoomLayoutHeight() - 1));
            GameObject[] spawns = room.GetComponent<Spawns>().GetSpawns();

            //pick random spawn
            Vector3 location = spawns[Random.Range(0, spawns.Length - 1)].transform.position;
            location.y = 3.5f;
            //instaniate magic
            obj = Instantiate(healthPotion, location, rot) as GameObject;
        }

        for (int i = 0; i < j; i++) {
            //get spawns from room
            GameObject room = roomRandomizer.GetRoom(Random.Range(0, roomRandomizer.GetRoomLayoutWidth() - 1), Random.Range(0, roomRandomizer.GetRoomLayoutHeight() - 1));
            GameObject[] spawns = room.GetComponent<Spawns>().GetSpawns();

            //pick random spawn
            Vector3 location = spawns[Random.Range(0, spawns.Length - 1)].transform.position;
            location.y = 3.5f;
            //instaniate magic
            obj = Instantiate(manaPotion, location, rot) as GameObject;
        }
    }
}
