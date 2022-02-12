using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Magic", menuName = "MagicInfo")]
public class Magic : ScriptableObject {
    // Start is called before the first frame update
    [SerializeField] private new string name;
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float manaConsumed;
    [SerializeField] private int select = 0;
    [SerializeField] private Sprite image;

    public string getName() {
        return name;
    }

    public float getRange() {
        return range;
    }

    public float getDamage() {
        return damage;
    }

    public float getManaCost() {
        return manaConsumed;
    }

    public int getSelect() {
        return select;
    }

    public void setSelect(int num) {
        select = num;
    }

    public Sprite GetImage() {
        return image;
    }

}
