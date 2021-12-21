using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeNikudButton : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    public AudioClip[] audioClips;


    private int indexButtonCliced;

    public AudioSource audioSource;
    public bool IsClicked;

    private Dictionary<Button, AudioClip> dict = new Dictionary<Button, AudioClip>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        IsClicked = false;

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

        IsClicked = true;

    }


    public int IndexButtonCliced
    {
        get { return indexButtonCliced; }

    }


}
