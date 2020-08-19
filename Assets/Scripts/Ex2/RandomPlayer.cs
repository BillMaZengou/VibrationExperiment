﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour
{
    private AudioClip Sound;
    private GameObject SoundType;
    private GameObject SoundPlayer;
    private AudioSource audioSource;

    public List<GameObject> PosSoundTypes;
    public List<GameObject> NegSoundTypes;

    private bool playOrNot;
    public bool PosOrNeg;
    public int whichOne;

    // Start is called before the first frame update
    void Start()
    {
        SoundPlayer = GameObject.Find("Audio Source");
        audioSource = SoundPlayer.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playOrNot = gameObject.GetComponent<InputTest>().ifPlay;
        //Debug.Log(playOrNot);
        if (playOrNot)
        {
            float PosOrNegThresh = Random.value;
            if (PosOrNegThresh < 0.5f)
            {
                PosOrNeg = false;  // Play negative
            }
            else { PosOrNeg = true; }  // Play positive

            if (PosOrNeg)
            {
                whichOne = (int)Random.Range(-0.4f, PosSoundTypes.Count - 0.6f);
                SoundType = PosSoundTypes[whichOne];
                FindSound();
                PlaySound();
            }
            else
            {
                whichOne = (int)Random.Range(-0.4f, NegSoundTypes.Count - 0.6f);
                SoundType = NegSoundTypes[whichOne];
                FindSound();
                PlaySound();
            }
        }
        else {
            audioSource.Stop();
        }
    }

    private void PlaySound()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = Sound;
        audioSource.volume = 1.0f;
        audioSource.Play();
    }

    private void FindSound()
    {
        DarkArtsStudios.SoundGenerator.Composition bounceComposition = SoundType.GetComponent<DarkArtsStudios.SoundGenerator.Composition>();
        //Debug.Log(SoundType);
        DarkArtsStudios.SoundGenerator.Module.Output output = null;
        foreach (DarkArtsStudios.SoundGenerator.Module.BaseModule module in bounceComposition.modules)
        {
            //Debug.Log(module);
            if (module.GetType() == typeof(DarkArtsStudios.SoundGenerator.Module.Output))
            {
                output = module as DarkArtsStudios.SoundGenerator.Module.Output;
                break;
            }
        }
        if (output)
        {
            output.Generate();
            Sound = output.audioClip;
        }
    }

}
