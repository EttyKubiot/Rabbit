using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayDrum : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private AudioClip[] audioClips;


    private int indexButtonCliced;

    private AudioSource audioSource;
   
    private Dictionary<Button, AudioClip> dict = new Dictionary<Button, AudioClip>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

       

        for (int i = 0; i < buttons.Length; i++)
        {
            dict.Add(buttons[i], audioClips[i]);

            int cacheIndex = i;
            buttons[i].onClick.AddListener(() => buttonCallBack(buttons[cacheIndex], audioClips[cacheIndex], cacheIndex));

        }



    }

    private void buttonCallBack(Button buttonCliced, AudioClip audioClipsPlaying, int index)
    {

        Debug.Log(buttonCliced);
        Debug.Log("index button" + index);

        indexButtonCliced = index;

        audioSource.clip = audioClipsPlaying;
        audioSource.Play();

      

    }


    
}
