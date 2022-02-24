using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRandomizer : MonoBehaviour {
    public static int roomMax = 6;
    public GameObject[] roomPrefabs;
    GameObject[,] roomLayout;

    private void Start() {
        roomLayout = new GameObject[3, 3];
    }

    public void LoadLevel() {
        RandomSelect();
        SpawnRoom();
    }

    private void RandomSelect() {
        for (int i = 0; i < roomLayout.GetLength(0); i++) {
            for (int j = 0; j < roomLayout.GetLength(1); j++) {
                roomLayout[i, j] = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
            }
        }
    }

    private void SpawnRoom() {
        for (int i = 0; i < roomLayout.GetLength(0); i++) {
            for (int j = 0; j < roomLayout.GetLength(1); j++) {
                Vector3 location = new Vector3(i*105, 0, j*105 + 40);
                Instantiate(roomLayout[i, j], location, Quaternion.identity);            
            }
        }
        
    }

    public bool CheckValidRoom(float posx, float posz, string direction) {
        float x = posx / 105;
        int newx = (int)System.Math.Round(x);
        float z = posz / 105;
        int newz = (int)System.Math.Round(x);
        bool result;

        if(direction == "left") {
            if (x < 0) {
                result = false;
            } else {
                result = true;
            }
        } else if(direction == "right") {
            if (x > roomLayout.GetLength(0) - 1) {
                result = false;
            } else {
                result = true;
            }
        } else if(direction == "b") {
            if (z < 0) {
                result = false;
            } else {
                result = true;
            }
        } else {
            if (z > roomLayout.GetLength(0) - 1) {
                result = false;
            } else {
                result = true;
            }
        }

        return result;
    }

    public int[] CheckRoomPos(float posx, float posz) {
        float x = (posx + 52) / 105;
        int newx = (int)System.Math.Floor(x);
        float z = (posz + 52) / 105;
        int newz = (int)System.Math.Floor(z);
        int[] nums = new int[2];
        nums[0] = newx;
        nums[1] = newz;
        return nums;
    }

    public GameObject GetRoom(int x, int z) {
        return roomLayout[x, z];
    }
}
