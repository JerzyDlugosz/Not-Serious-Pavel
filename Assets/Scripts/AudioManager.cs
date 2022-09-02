using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private float sliderVolume;
    public int levelMusic;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        sliderVolume = sounds[14].source.volume;
    }

    public void Start()
    {
        PlaySound("relax");
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            //Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            //Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void ChangeVolumeToZero(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            //Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        s.source.volume = 0;
    }

    public void ChangeVolumeToMax(string name)
    {
        Sound s = Array.Find(sounds, sound => sound._name == name);
        if (s == null)
        {
            //Debug.LogWarning("sound: " + name + " not found");
            return;
        }
        s.source.volume = sliderVolume;
    }

    public void ChangeSounds(int choice)
    {
        levelMusic = choice;
        if (choice == 0)
        {
            StopAllSounds();
            PlaySound("relax");
        }
        if (choice == 1)
        {
            StopAllSounds();
            PlaySound("fight-music");
            PlaySound("relax-music");
        }
        if (choice == 2)
        {
            StopAllSounds();
            PlaySound("guitar");
        }
        if (choice == 3)
        {
            // boss
        }
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            if (s.source.volume != 0)
            {
                s.source.volume = volume;
            }
        }
        sliderVolume = volume;
    }

    public void StopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            StopSound(s._name);
        }
    }
}
