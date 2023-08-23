using System;
using UnityEngine;

public class SoundZoneTrigger : MonoBehaviour
{
    public AudioSource soundSource;
    private bool isInsideZone = false;

    private void Awake()
    {
        if (soundSource == null)
        {
            //проверка чтобы не париться в рантайме
            throw new NullReferenceException("Sound source is null");
        }
    }

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
