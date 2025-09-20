using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip audioClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CloudCrash()
    {
        audioClip = Resources.Load<AudioClip>("Crash");
        audioSource.PlayOneShot(audioClip);
    }

    public static void Meteor()
    {
        audioClip = Resources.Load<AudioClip>("Meteor 1");
        audioSource.PlayOneShot(audioClip);
    }

    public static void Goal()
    {
        audioClip = Resources.Load<AudioClip>("Goal");
        audioSource.PlayOneShot(audioClip);
    }
}
