using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyUI : MonoBehaviour
{
    [SerializeField] private Text[] keyText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CurectClicks curectClicks;
    [SerializeField] private int indexButtonClicked;
    //[SerializeField] private List<Text> listOfLetters = new List<Text>();

    public int IndexButtonClicked => indexButtonClicked;

    public AudioSource audioSource;

    private void Start()
    {
        gameManager.OnSucsessWord += ClearText;
    }
    public void UpdateDisplayUI(KeyData keydData)
    {

        indexButtonClicked = keydData.Index;

        keyText[curectClicks.LetterPress].text = keydData.Key1;

        audioSource.clip = keydData.AudioClips;
        audioSource.Play();
       
        gameManager.OnClickKey?.Invoke(indexButtonClicked);

    }

    public void ClearText()
    {
        for (int i = 0; i < keyText.Length; i++)
        {
            keyText[i].text = string.Empty;

        }
    }

    
}