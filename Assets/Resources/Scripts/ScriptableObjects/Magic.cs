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
    [SerializeField] private float cooldownMax;
    [SerializeField] private float cooldownCurrent;
    [SerializeField] private int select;
    [SerializeField] private Sprite image;
    [SerializeField] private ParticleSystem particles;

    void Start() {
        Debug.Log("Reset");
        select = 0;
        cooldownCurrent = 0;
    }

    public string GetName() {
        return name;
    }

    public float GetRange() {
        return range;
    }

    public float GetDamage() {
        return damage;
    }

    public float GetManaCost() {
        return manaConsumed;
    }

    public int GetSelect() {
        return select;
    }

    public void SetSelect(int num) {
        select = num;
    }

    public Sprite GetImage() {
        return image;
    }

    public ParticleSystem GetParticles() {
        return particles;
    }

    public float GetCooldownCurrent() {
        return cooldownCurrent;
    }

    public void SetCooldownCurrent(float num) {
        cooldownCurrent = num;
    }

    public float GetCooldownMax() {
        return cooldownMax;
    }
}
