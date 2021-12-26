using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NikudUI : MonoBehaviour
{
    [SerializeField] private Image[] nikudSprite;
    [SerializeField] private Image[] transparencySprite;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private KeyUI keyUI;
    [SerializeField] private CorrectClicks correctClicks;
    [SerializeField] private AudioSource audioSource;

    private int indexNikudClicked;
    private AudioClip[] audioNikudClicked;
    private List<AudioClip> listToRead = new List<AudioClip>();

    public int IndexNikudClicked => indexNikudClicked;
    public AudioClip[] AudioNikudClicked => audioNikudClicked;
    public List<AudioClip> ListToRead => listToRead;


    private void Start()
    {
        gameManager.OnSucsessWord += ClaerImg;
        gameManager.OnSucsessWord += ClaerListToRead;
    }

    public void UpdateDisplayUI(KeyNikudData keyNikudData)
    {

        indexNikudClicked = keyNikudData.Index;

        audioNikudClicked = keyNikudData.AudioClips;

        nikudSprite[correctClicks.RightClicks].sprite = keyNikudData.Icon;

        audioSource.clip = keyNikudData.AudioClips[keyUI.IndexButtonClicked];
        audioSource.Play();

        gameManager.OnClickNikudKey?.Invoke(indexNikudClicked);

    }

    private void ClaerImg()
    {
       
        for (int i = 0; i < nikudSprite.Length; i++)
        {
            nikudSprite[i].sprite = transparencySprite[i].sprite;

        }
    }

    private void ClaerListToRead()
    {
            listToRead.Clear();
    }

}