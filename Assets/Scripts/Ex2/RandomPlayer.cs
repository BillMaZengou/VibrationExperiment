using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayer : MonoBehaviour
{
    private AudioClip Sound;
    private GameObject SoundType;
    private GameObject SoundPlayer;
    private AudioSource audioSource;

    public GameObject symmetricWave;
    public List<GameObject> PosSoundTypes;
    public List<GameObject> NegSoundTypes;

    private bool playOrNot;
    public bool ifSine;
    public bool PosOrNeg;
    public int whichOne = 1000;

    // Start is called before the first frame update
    void Start()
    {
        SoundPlayer = GameObject.Find("Audio Source");
        audioSource = SoundPlayer.GetComponent<AudioSource>();
        ifSine = false;
    }

    // Update is called once per frame
    void Update()
    {
        playOrNot = gameObject.GetComponent<InputTest>().ifPlay;
        if (playOrNot)
        {
            ifSine = false;
            float idx = Random.value;
            if (idx < 0.09)
            {
                PosOrNeg = true;
                whichOne = 0;
            }
            else if (idx < 0.18 && idx >= 0.09)
            {
                PosOrNeg = true;
                whichOne = 1;
            }
            else if (idx < 0.27 && idx >= 0.18)
            {
                PosOrNeg = true;
                whichOne = 2;
            }
            else if (idx < 0.36 && idx >= 0.27)
            {
                PosOrNeg = true;
                whichOne = 3;
            }
            else if (idx < 0.45 && idx >= 0.36)
            {
                PosOrNeg = true;
                whichOne = 4;
            }
            else if (idx < 0.54 && idx >= 0.45)
            {
                PosOrNeg = false;
                whichOne = 0;
            }
            else if (idx < 0.63 && idx >= 0.54)
            {
                PosOrNeg = false;
                whichOne = 1;
            }
            else if (idx < 0.72 && idx >= 0.63)
            {
                PosOrNeg = false;
                whichOne = 2;
            }
            else if (idx < 0.81 && idx >= 0.72)
            {
                PosOrNeg = false;
                whichOne = 3;
            }
            else if (idx < 0.90 && idx >= 0.81)
            {
                PosOrNeg = false;
                whichOne = 4;
            }
            else
            {
                ifSine = true;
            }

            if (ifSine)
            {
                SoundType = symmetricWave;
                FindSound();
                PlaySound();
            }
            else
            {
                if (PosOrNeg)
                {
                    SoundType = PosSoundTypes[whichOne];
                    FindSound();
                    PlaySound();
                }
                else
                {
                    SoundType = NegSoundTypes[whichOne];
                    FindSound();
                    PlaySound();
                }
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
        DarkArtsStudios.SoundGenerator.Module.Output output = null;
        foreach (DarkArtsStudios.SoundGenerator.Module.BaseModule module in bounceComposition.modules)
        {
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
