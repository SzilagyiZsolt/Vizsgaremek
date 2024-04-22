using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource effectSource;

    public AudioMixer myMixer;
    public Slider musicSlider;
    public Text musicText;
    public Slider effectSlider;
    public Text effectText;
    public AudioClip[] music;
    public AudioClip[] knightEffects;
    public AudioClip[] archerEffects;
    public AudioClip[] arena3Effects;
    public int random;
    public float newMusic;
    public float timer;
    private void Start()
    {
        LoadMusicValues();
        LoadEffectValues();
        musicSource.PlayOneShot(music[0]);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= newMusic)
        {
            randommusic();
            timer = 0;
        }
    }
    public void SetDefault()
    {
        musicSlider.value = (float)1.0;
        effectSlider.value = (float)1.0;
    }
    public void MusicVolumeText(float volume)
    {
        musicText.text = volume.ToString("0" + "%");
    }
    public void EffectVolumeText(float volume)
    {
        effectText.text = volume.ToString("0" + "%");
    }
    public void SaveMusicVolumeButton()
    {
        float musicValue = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(musicValue) * 20);
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        LoadMusicValues();
    }
    public void SaveEffectVolumeButton()
    {
        float effectValue = effectSlider.value;
        myMixer.SetFloat("Effect", Mathf.Log10(effectValue) * 20);
        PlayerPrefs.SetFloat("EffectValue", effectValue);
        LoadEffectValues();
    }
    public void LoadMusicValues()
    {
        float musicValue = PlayerPrefs.GetFloat("MusicValue");
        musicSlider.value = musicValue;
        musicSource.volume = musicValue;
    }
    public void LoadEffectValues()
    {
        float effectValue = PlayerPrefs.GetFloat("EffectValue");
        effectSlider.value = effectValue;
        effectSource.volume = effectValue;
    }
    public void randommusic()
    {
        if (!musicSource.isPlaying)
        {
            Debug.Log("ok");
            random = Random.Range(0, music.Length);
            musicSource.volume = (float)0.5;
            musicSource.PlayOneShot(music[random]);
            newMusic = music[random].length;
            LoadMusicValues();
            LoadEffectValues();
        }
    }
    public void playSFX(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
}
