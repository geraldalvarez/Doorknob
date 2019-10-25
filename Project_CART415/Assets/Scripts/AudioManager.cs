﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
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
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.spatialBlend = s.spatialBlend;
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;

            if (s.rolloffMode == 0)
            {
                s.source.rolloffMode = AudioRolloffMode.Logarithmic;
            }
            else if (s.rolloffMode == 1)
            {
                s.source.rolloffMode = AudioRolloffMode.Linear;
            }
            else
            {
                Debug.LogWarning("Select a Rolloff Mode");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
        //s.source.PlayOneShot(s.clip, s.volume);
    }
}
