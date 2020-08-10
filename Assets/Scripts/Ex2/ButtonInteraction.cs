using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{

    private AudioClip Sound;
    private GameObject SoundType;
    private GameObject SoundPlayer;

    private void PlaySound()
    {
        SoundPlayer = GameObject.Find("Audio Source");
        //Debug.Log(SoundPlayer);
        AudioSource audioSource = SoundPlayer.GetComponent<AudioSource>();
        //Debug.Log(audioSource);

        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = Sound;
        audioSource.volume = 1.0f;
        audioSource.Play();
        Debug.Log("Done");
    }

    private void FindSound()
    {
        DarkArtsStudios.SoundGenerator.Composition bounceComposition = SoundType.GetComponent<DarkArtsStudios.SoundGenerator.Composition>();
        Debug.Log(SoundType);
        DarkArtsStudios.SoundGenerator.Module.Output output = null;
        foreach (DarkArtsStudios.SoundGenerator.Module.BaseModule module in bounceComposition.modules)
        {
            Debug.Log(module);
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

    public void OnPosAsymSineClicked()
    {
        SoundType = GameObject.Find("InputSignal/Positive/AysmmetricSine");
        FindSound();
        PlaySound();
    }

    public void OnPosThreeToOneClicked()
    {
        SoundType = GameObject.Find("InputSignal/Positive/ThreeToOne");
        FindSound();
        PlaySound();
    }


    public void OnPosRampClicked()
    {
        SoundType = GameObject.Find("InputSignal/Positive/Ramp");
        FindSound();
        PlaySound();
    }

    public void OnPosSquareClicked()
    {
        SoundType = GameObject.Find("InputSignal/Positive/SquareSignal");
        FindSound();
        PlaySound();
    }

    public void OnPosHapCubeClicked()
    {
        SoundType = GameObject.Find("InputSignal/Positive/HapCube");
        FindSound();
        PlaySound();
    }

    //public void OnPosHalfSineClicked()
    //{
    //    SoundType = GameObject.Find("InputSignal/Positive/HalfSine");
    //    FindSound();
    //    PlaySound();
    //}

    public void OnNegAsymSineClicked()
    {
        SoundType = GameObject.Find("InputSignal/Negative/RevAysmmetricSine");
        FindSound();
        PlaySound();
    }

    public void OnNegThreeToOneClicked()
    {
        SoundType = GameObject.Find("InputSignal/Negative/RevThreeToOne");
        FindSound();
        PlaySound();
    }


    public void OnNegRampClicked()
    {
        SoundType = GameObject.Find("InputSignal/Negative/RevRamp");
        FindSound();
        PlaySound();
    }

    public void OnNegSquareClicked()
    {
        SoundType = GameObject.Find("InputSignal/Negative/RevSquareSignal");
        FindSound();
        PlaySound();
    }

    public void OnNegHapCubeClicked()
    {
        SoundType = GameObject.Find("InputSignal/Negative/RevHapCube");
        FindSound();
        PlaySound();
    }

    //public void OnNegHalfSineClicked()
    //{
    //    SoundType = GameObject.Find("InputSignal/Negative/RevHalfSine");
    //    FindSound();
    //    PlaySound();
    //}
}
