using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    private AudioSource SoundSource;
    private List<AudioClip> Sounds;
    private int RNG;
    private int SoundsID;
    private void Start()
    {
        SoundSource = GetComponent<AudioSource>();
        RNG = 0;
        Sounds = new List<AudioClip>();
        if (gameObject.name.Contains("Ball"))
        {
            SoundsID = 0;
        }
        else
        {
            SoundsID = 1;
        }
        CheckSounds();
    }
    private void OnCollisionEnter(Collision other)
    {
        RNG = Random.Range(0, Sounds.Count);
        SoundSource.PlayOneShot(Sounds[RNG]);
    }

    void CheckSounds()
    {
        switch (SoundsID)
        {
            case 0: 
                foreach (AudioClip ac in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/Bounces"))
                {
                    Sounds.Add(ac);
                }

                break;
            case 1:
                foreach (AudioClip ac in Resources.LoadAll<AudioClip>("Sounds/Sound Effects/Thumps"))
                {
                    Sounds.Add(ac);
                }
                break;
        }
    }
}