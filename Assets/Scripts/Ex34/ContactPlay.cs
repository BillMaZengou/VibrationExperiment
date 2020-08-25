using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPlay : MonoBehaviour
{
    private AudioClip Sound;
    private GameObject SoundType;
    private GameObject SoundPlayer;
    private AudioSource audioSource;

    public List<GameObject> PosSoundTypes;
    public List<GameObject> NegSoundTypes;

    public bool PosOrNeg;  // True for positve; False for negative
    public int PosWhichOne;
    /*
    1 -> Asymmetric Sine
    2 -> Three to one sine
    3 -> Ramp
    4 -> Square
    5 -> HapCube
    */
    public int NegWhichOne;
    private bool ifPlay;
    // Start is called before the first frame update
    void Start()
    {
        SoundPlayer = GameObject.Find("Audio Source");
        audioSource = SoundPlayer.GetComponent<AudioSource>();
        ifPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ifPlay)
        {
            PlaySound();
        }
        else {
            audioSource.Stop();
        }
    }

    private void OnDisable()
    {
        audioSource.Stop();
        ifPlay = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("mover"))
        {
            if (PosOrNeg)
            {
                SoundType = PosSoundTypes[PosWhichOne - 1];
            }
            else
            {
                SoundType = NegSoundTypes[NegWhichOne - 1];
            }
            FindSound();
            ifPlay = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ifPlay = false;
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
