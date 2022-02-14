using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour {
    [SerializeField] GameObject[] spawns;

    public GameObject[] GetSpawns() {
        return spawns;
    }
}
