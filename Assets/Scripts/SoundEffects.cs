using System;
using UnityEngine;


public class SoundEffects : MonoBehaviour
{
    [Header("Effect Sounds")] 
    public AudioClip telekineticSound;
    public AudioClip shrinkSound;
    public AudioClip growSound;
    public AudioClip jumpSound;
    
    private AudioSource audioSource;
    private bool isPlaying;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        if (soundName == "telekinetic" && !isPlaying)
        {
            audioSource.clip = telekineticSound;
            audioSource.loop = true;
            audioSource.volume = 1f;
            audioSource.Play();
            isPlaying = true;
        } 
        else if (soundName == "shrink" && !isPlaying)
        {
            audioSource.clip = shrinkSound;
            audioSource.loop = false;
            audioSource.volume = 1f;
            audioSource.Play();
            isPlaying = true;
        } 
        else if (soundName == "grow" && !isPlaying)
        {
            audioSource.clip = growSound;
            audioSource.loop = false;
            audioSource.volume = 1f;
            audioSource.Play();
            isPlaying = true;
        } 
        else if (soundName == "jump" && !isPlaying)
        {
            audioSource.clip = jumpSound;
            audioSource.loop = false;
            audioSource.volume = .5f;
            audioSource.Play();
            isPlaying = true;
        }
    }

    public void StopSound()
    {
        if (isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
