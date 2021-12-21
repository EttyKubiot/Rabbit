using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New KeyNikud Data", menuName = "KeyNikud Data", order = 54)]

public class KeyNikudData : ScriptableObject
{

    [SerializeField] private AudioClip[] audioClips;

    public AudioClip[] AudioClips => audioClips;

   
}
