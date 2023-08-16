using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZoneTrigger : MonoBehaviour
{
    public AudioSource soundSource; // —сылка на аудио источник
    private bool isInsideZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideZone = true;
            PlaySound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideZone = false;
            StopSound();
        }
    }

    private void PlaySound()
    {
        if (soundSource != null && !soundSource.isPlaying && isInsideZone)
        {
            soundSource.Play();
        }
    }

    private void StopSound()
    {
        if (soundSource != null && soundSource.isPlaying && !isInsideZone)
        {
            soundSource.Stop();
        }
    }
}
