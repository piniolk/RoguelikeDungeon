using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour {
    [SerializeField] private AudioSource AudioSource;
    public GameObject objectMusic;
    [SerializeField] private Slider slider;

    private float musicVolume = 1f;
   /* private void Awake() {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/

    // Start is called before the first frame update
    void Start() {
        objectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = objectMusic.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume", 1f);
        AudioSource.volume = musicVolume;
        slider.value = musicVolume;
    }

    // Update is called once per frame
    void Update() {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void UpdateVolume(float volume) {
        musicVolume = volume;
    }

}
