using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyUI : MonoBehaviour
{
    [SerializeField] private Text[] keyText;
    [SerializeField] private List<Text> listOfLetters = new List<Text>();

    [SerializeField] private int index1;

    public int Index1 => index1;
    public AudioSource audioSource;

    public void UpdateDisplayUI(KeyData keydData)
    {
        // for (int i = 0; i < keyText.Length; i++)

        index1 = keydData.Index;
            if (string.IsNullOrEmpty(keyText[0].text))
            {
                keyText[0].text = keydData.Key1;
                //listOfLetters.Add(keyText[0]);
            }

            else if (keyText[0] != null && string.IsNullOrEmpty(keyText[1].text))
            {
            keyText[1].text = keydData.Key1;
            //listOfLetters.Add(keyText[1]);
            }

            else if (keyText[1] != null && keyText[1] != null)
            {
            keyText[2].text = keydData.Key1;
            //listOfLetters.Add(keyText[2]);
            }

            





        audioSource.clip = keydData.AudioClips;
        audioSource.Play();

       
    }
}