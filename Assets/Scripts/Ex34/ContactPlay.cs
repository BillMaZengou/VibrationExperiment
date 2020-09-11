using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPlay : MonoBehaviour
{
    private AudioClip Sound;
    private DarkArtsStudios.SoundGenerator.Composition SoundType;
    private GameObject SoundPlayer;
    private AudioSource audioSource;

    public DarkArtsStudios.SoundGenerator.Composition PosSoundType;
    public DarkArtsStudios.SoundGenerator.Composition Sine;

    public bool vibration; // True for vibration; False for only vision
    public bool symmetric; // True for symmetric; Falso for asymmetric

    private bool ifPlay;

    public bool ifRandomise;  // True for randomising the waveforms
    private float randomTrigger = 0.0f;
    public List<DarkArtsStudios.SoundGenerator.Composition> RandomRange;
    private int randomIdx;

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
        if (ifRandomise)
        {
            randomTrigger++;
            if (randomTrigger%5.0f == 0.0f)
            {
                randomIdx = Random.Range(0, RandomRange.Count);
            }
        }

        if (vibration)
        {
            if (ifPlay)
            {
                PlaySound();
            }
            else
            {
                audioSource.Stop();
            }
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
            if (symmetric)
            {
                SoundType = Sine;
            }
            else
            {
                if (ifRandomise)
                {
                    SoundType = RandomRange[randomIdx];
                    //Debug.Log(randomIdx);
                }
                else
                {
                    SoundType = PosSoundType;
                }
            }
            FindSound();
            Debug.Log(SoundType);
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
        DarkArtsStudios.SoundGenerator.Module.Output output = null;
        foreach (DarkArtsStudios.SoundGenerator.Module.BaseModule module in SoundType.modules)
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
