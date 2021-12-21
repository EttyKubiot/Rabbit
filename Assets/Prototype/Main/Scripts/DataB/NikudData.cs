using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Nikud Data", menuName = "Nikud Data", order = 54)]


public class NikudData : ScriptableObject
{
   
    [SerializeField] private AudioClip audioClips;
    [SerializeField] private Sprite icon;
    [SerializeField] private int index;


    public Sprite Icon => icon;
    public int Index => index;

    public AudioClip AudioClips => audioClips;

    
}
