using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadKeyNikud : MonoBehaviour

{


    public AudioSource audioSource;
   [SerializeField] private KeyUI keyUI;


    public void Read(KeyNikudData keyNikudData)
    {
        audioSource.clip = keyNikudData.AudioClips[keyUI.Index1];
        audioSource.Play();
    }
    
}
