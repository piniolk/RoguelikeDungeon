using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour {
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioSource volumeAudioSource;
    public GameObject objectMusic;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider slider;
    [SerializeField] private TMPro.TMP_Dropdown dropdown;
    [SerializeField] private AudioClip streetLove;
    [SerializeField] private AudioClip chunkyMonkey;
    [SerializeField] private AudioClip tinyBlocks;
    [SerializeField] private AudioClip sunnyDay;

    private float musicVolume = 1f;
    private float soundVolume = 1f;
    private string songType = "Street Love";
   /* private void Awake() {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }*/

    // Start is called before the first frame update
    void Awake() {
        objectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = objectMusic.GetComponent<AudioSource>();
        musicVolume = PlayerPrefs.GetFloat("volume", 1f);
        soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        AudioSource.volume = musicVolume;
        slider.value = musicVolume;
        volumeSlider.value = soundVolume;
        volumeAudioSource.volume = soundVolume;
        songType = PlayerPrefs.GetString("SongType", "Street Love");
        AssignSong();
        DefaultSong();
    }

    public void UpdateVolume(float volume) {
        musicVolume = volume;
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void UpdateSoundVolume(float volume) {
        soundVolume = volume;
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        volumeAudioSource.volume = soundVolume;
        volumeAudioSource.Play();
    }

    public void UpdateMusic(TMPro.TMP_Dropdown target) {
        //Debug.Log("Selected: " + dropdown.options[target.value].text);
        songType = dropdown.options[target.value].text;
        PlayerPrefs.SetString("SongType", songType);
        AssignSong();
    }

    private void AssignSong() {
        if(songType == "Street Love") {
            AudioSource.clip = streetLove;
        } else if(songType == "Chunky Monkey") {
            AudioSource.clip = chunkyMonkey;
        } else if(songType == "Tiny Blocks") {
            AudioSource.clip = tinyBlocks;
        } else if(songType == "Sunny Day") {
            AudioSource.clip = sunnyDay;
        }
        AudioSource.Play();
    }

    private void DefaultSong() {
        if (songType == "Street Love") {
            dropdown.value = 0;
        } else if (songType == "Chunky Monkey") {
            dropdown.value = 1;
        } else if (songType == "Tiny Blocks") {
            dropdown.value = 2;
        } else if (songType == "Sunny Day") {
            dropdown.value = 3;
        }
    }
}
