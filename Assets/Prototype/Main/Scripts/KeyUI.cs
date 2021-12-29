using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    [Space(10)]
    [Header("Refernces")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CorrectClicks correctClicks;
    [SerializeField] private AudioSource audioSource;

    private int indexButtonClicked;
    [SerializeField] private Text[] keyText;
    public int IndexButtonClicked => indexButtonClicked;

    private void Start()
    {
        gameManager.OnSucsessWord += ClearText;
    }
    public void UpdateDisplayUI(KeyData keydData)
    {
        if (correctClicks.ReadingWord == false)
        {
            indexButtonClicked = keydData.Index;

            keyText[correctClicks.RightClicks].text = keydData.Key1;

            audioSource.clip = keydData.AudioClips;
            audioSource.Play();

            gameManager.OnClickKey?.Invoke(indexButtonClicked);
        }
    }

    public void ClearText()
    {
        for (int i = 0; i < keyText.Length; i++)
        {
            keyText[i].text = string.Empty;

        }
    }

    
}