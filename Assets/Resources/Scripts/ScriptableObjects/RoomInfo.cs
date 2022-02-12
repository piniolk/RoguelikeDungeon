using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "RoomInfo")]
public class RoomInfo : ScriptableObject {
    // Start is called before the first frame update
    GameObject room;
    GameObject roomLeft = null;
    GameObject roomUp = null;
    GameObject roomRight = null;
    GameObject roomDown = null;

    public GameObject GetRoomType() {
        return room;
    }

    public GameObject GetRoomLeftType() {
        return roomLeft;
    }

    public GameObject GetRoomUpType() {
        return roomUp;
    }

    public GameObject GetRoomRightType() {
        return roomRight;
    }

    public GameObject GetRoomDownType() {
        return roomDown;
    }

    public void SetRoomLeftType(GameObject room) {
        roomLeft = room;
    }

    public void SetRoomUpType(GameObject room) {
        roomUp = room;
    }

    public void SetRoomRightType(GameObject room) {
        roomRight = room;
    }

    public void SetRoomDownType(GameObject room) {
        roomDown = room;
    }
}
