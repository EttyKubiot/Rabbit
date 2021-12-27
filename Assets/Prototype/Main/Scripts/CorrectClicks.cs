using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CorrectClicks : MonoBehaviour
{
    private int rightClicks;
    private int wordsIndex;

    private bool corectNickudClick;
    private bool corectLetterClick;
    private int indexCorectLetterClick;

    [SerializeField] private Image picture;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private NikudUI nikudUI;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private WordData[] words;
    public int RightClicks => rightClicks;

    private void Start()
    {
        wordsIndex = 0;
        rightClicks = 0;
        corectLetterClick = false;
        corectNickudClick = false;
        gameManager.OnClickKey += CheckIfClickLetterCorrect;
        gameManager.OnClickNikudKey += CheckIfClickNikudCorrect;
    }


    public void CheckIfClickLetterCorrect(int indexButton)
    {
        if (words[wordsIndex].letters[rightClicks] == indexButton)
        {
            Debug.Log("sucsess");
            corectLetterClick = true;
            indexCorectLetterClick = indexButton;
            Currect();
        }
        else
        {
            Debug.Log("Error");
            corectLetterClick = false;
            gameManager.Health++;
        }
    }

    public void CheckIfClickNikudCorrect(int indexNikudButton)
    {
        if (words[wordsIndex].nikud[rightClicks] == indexNikudButton)
        {
            Debug.Log("sucsessNikud");
            corectNickudClick = true;
           
            Currect();
        }
        else
        {
            Debug.Log("Error");
            corectNickudClick = false;
            gameManager.Health++;
        }
    }

    public void Currect()
    {

        if (corectLetterClick == true && corectNickudClick == true) 
        {
            corectLetterClick = false;
            corectNickudClick = false;

            nikudUI.ListToRead.Add(nikudUI.AudioNikudClicked[indexCorectLetterClick]);

            if (rightClicks + 1 >= words[wordsIndex].letters.Length)
            {
                Debug.Log("sucsess word");
                gameManager.Score += 10;
                gameManager.Health = 0;
                rightClicks = 0;
                wordsIndex = (wordsIndex + 1) % words.Length;
                picture.gameObject.GetComponent<Image>().sprite = words[wordsIndex].wordSprite;


                StartCoroutine(RaedWord());
                StartCoroutine(SucsessWord());
            }
            else
            {
                rightClicks = (rightClicks + 1) % words[wordsIndex].letters.Length;

            }
        }

        else
        {
            return;
        }
    }

    private IEnumerator SucsessWord()
    {
        yield return new WaitForSeconds(4f);
        gameManager.OnSucsessWord?.Invoke();
    }


    private IEnumerator RaedWord()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < words[wordsIndex].nikud.Length; i++)
        {
            audioSource.clip = nikudUI.ListToRead[i];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);

        }

    }

}
