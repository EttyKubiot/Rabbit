using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NikudUI : MonoBehaviour
{
    [SerializeField] private Image[] nikudSprite;
    //[SerializeField] private List<Image> listOfLetters = new List<Image>();


    [SerializeField] private GameManager gameManager;
    [SerializeField] private KeyUI keyUI;
    [SerializeField] private CurectClicks curectClicks;
    [SerializeField] private int indexNikudClicked;

    public int IndexNikudClicked => indexNikudClicked;

    public AudioSource audioSource;

    private void Start()
    {
        gameManager.OnSucsessWord += ClaerImg;
    }


    public void UpdateDisplayUI(KeyNikudData keyNikudData)
    {

        indexNikudClicked = keyNikudData.Index;

        nikudSprite[curectClicks.LetterPress].sprite = keyNikudData.Icon;

        audioSource.clip = keyNikudData.AudioClips[keyUI.IndexButtonClicked];
        audioSource.Play();

        gameManager.OnClickNikudKey?.Invoke(indexNikudClicked);



        //audioSource.clip = nikudData.AudioClips;
        //audioSource.Play();
        //סטארט קורואטין ותקרא לפונקציה של רידקיניקוד
        //StartCoroutine(ReadALL());

        //}

        //    private IEnumerator ReadALL()
        //{

        //    yield return new WaitForSeconds(0.05f);
        //    //readKeyNikud.ReadKeyAndNikud(ScriptableObject);
    }

    private void ClaerImg()
    {
        for (int i = 0; i < nikudSprite.Length; i++)
        {
            nikudSprite[i].sprite = default;

        }
    }

    
}