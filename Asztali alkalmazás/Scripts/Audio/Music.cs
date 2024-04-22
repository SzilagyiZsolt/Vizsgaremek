using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Music : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider musicSlider;
    public Text musicText;
    public AudioClip[] music;
    public new AudioSource audio;
    public float timer;
    public float newMusic;
    public int random;
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        LoadValues();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= newMusic)
        {
            newmusic();
            timer = 0;
        }
    }
    public void SetDefault()
    {
        musicSlider.value = (float)1.0;
    }
    public void VolumeText(float volume)
    {
        musicText.text=volume.ToString("0"+"%");
    }
    public void SaveVolumeButton()
    {
        float musicValue=musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(musicValue) *20);
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        LoadValues();
    }
    public void LoadValues()
    {
        float musicValue = PlayerPrefs.GetFloat("MusicValue");
        musicSlider.value = musicValue;
        AudioListener.volume= musicValue;
    }
    public void newmusic()
    {
        random = Random.Range(0, music.Length+1);
        if (!audio.isPlaying)
        {
            audio.volume = (float)0.5;
            audio.PlayOneShot(music[random]);
        }
        newMusic = music[random].length;
    }
    
}
