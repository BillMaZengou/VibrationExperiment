using System.Collections;
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
        //Debug.Log(SoundPlayer);
        audioSource = SoundPlayer.GetComponent<AudioSource>();
        //Debug.Log(audioSource);
    }

    // Update is called once per frame
    void Update()
    {
        playOrNot = gameObject.GetComponent<InputTest>().ifPlay;
        if (playOrNot) {
            float PosOrNegThresh = Random.value;
            if (PosOrNegThresh < 0.5f) {
                PosOrNeg = false;  // Play negative
            }
            else { PosOrNeg = true;  }  // Play positive

            if (PosOrNeg)
            {
                whichOne = (int)Random.Range(0.0f, PosSoundTypes.Count - 0.6f);
                SoundType = PosSoundTypes[whichOne];
                FindSound();
                PlaySound();
            }
            else {
                whichOne = (int)Random.Range(0.0f, NegSoundTypes.Count - 0.6f);
                SoundType = NegSoundTypes[whichOne];
                FindSound();
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = Sound;
        audioSource.volume = 1.0f;
        audioSource.Play();
        //Debug.Log("Done");
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
        //Debug.Log(output);
        if (output)
        {
            output.Generate();
            Sound = output.audioClip;
            //Debug.Log(Sound);
        }
    }

}
