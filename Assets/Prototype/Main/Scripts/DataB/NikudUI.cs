using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NikudUI : MonoBehaviour
{
    [SerializeField] private Image[] nikudSprite;
    [SerializeField] private List<Image> listOfLetters = new List<Image>();

    [SerializeField] private ReadKeyNikud readKeyNikud;
    public AudioSource audioSource;

    
    public void UpdateDisplayUI(NikudData nikudData)
    {
      
        if (nikudSprite[0].sprite == null)
        {
            nikudSprite[0].sprite = nikudData.Icon;
            //listOfLetters.Add(nikudSprite[0]);

        }

        else if (nikudSprite[0].sprite != null && nikudSprite[1].sprite == null)
        {
            nikudSprite[1].sprite = nikudData.Icon;
            //listOfLetters.Add(nikudSprite[1]);
        }

        else if (nikudSprite[0].sprite != null && nikudSprite[1].sprite != null)
        {
            nikudSprite[2].sprite = nikudData.Icon;
            //listOfLetters.Add(nikudSprite[2]);
        }

        

        //}





        //audioSource.clip = nikudData.AudioClips;
        //audioSource.Play();
        //סטארט קורואטין ותקרא לפונקציה של רידקיניקוד
        StartCoroutine(ReadALL());

    }

        private IEnumerator ReadALL()
    {
         
        yield return new WaitForSeconds(0.05f);
        //readKeyNikud.ReadKeyAndNikud(ScriptableObject);
      


    }


}