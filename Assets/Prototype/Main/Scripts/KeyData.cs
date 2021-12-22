using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key Data", menuName = "Key Data", order = 53)]

public class KeyData : ScriptableObject
{
    [SerializeField] private AudioClip audioClips;
    [SerializeField] private string key1;
    [SerializeField] private int index;

    public string Key1 => key1;
    public int Index => index;
    public AudioClip AudioClips => audioClips;

    

}
