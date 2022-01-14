using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRandomizer : MonoBehaviour {
    public static int roomMax = 6;
    public GameObject[] roomPrefabs;
    //public RoomInfo[] roomPrefabs;
    GameObject[][] roomLayout;
    //RoomInfo[][] roomLayout;

    public void LoadLevel() {

    }

    private GameObject RandomSelect() {
        int size = Random.Range(0, roomPrefabs.Length - 1);
        return roomPrefabs[size];
    }
}
