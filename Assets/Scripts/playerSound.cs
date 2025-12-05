using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class playerSound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip sonidoScore;
    public AudioClip sonidoChoque; 
    public AudioClip sonidoGanaste; 
    public AudioClip sonidoFondo;

    public void playSoundScore()
    {
        audioSource.PlayOneShot(sonidoScore);
    }

    public void playSoundChoque()
    {
        audioSource.PlayOneShot(sonidoChoque);
    }
    public void playSoundGanaste()
    {
        audioSource.PlayOneShot(sonidoGanaste);
    }
    public void playSoundFondo()
    {
        audioSource.PlayOneShot(sonidoFondo);
    }

    //ublic void stopSoundFondo()
    //{
    //    audioSource.Stop();
    //}
}
