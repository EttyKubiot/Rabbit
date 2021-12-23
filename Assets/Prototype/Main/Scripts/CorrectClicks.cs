using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectClicks : MonoBehaviour
{
    [SerializeField] private int[] letters;
    [SerializeField] private int[] nikud;
    private int rightClicks;

    private bool corectNickudClick;
    private bool corectLetterClick;
    private int indexCorectLetterClick;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private NikudUI nikudUI;
    [SerializeField] private AudioSource audioSource;
    public int RightClicks => rightClicks;

    private void Start()
    {
        rightClicks = 0;
        corectLetterClick = false;
        corectNickudClick = false;
        gameManager.OnClickKey += CheckIfClickLetterCorrect;
        gameManager.OnClickNikudKey += CheckIfClickNikudCorrect;
    }


    public void CheckIfClickLetterCorrect(int indexButton)
    {
        if (letters[rightClicks] == indexButton)
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
        if (nikud[rightClicks] == indexNikudButton)
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

            if (rightClicks + 1 >= letters.Length)
            {
                Debug.Log("sucsess word");
                gameManager.Score += 10;
                gameManager.Health = 0;
                rightClicks = 0;
                
                StartCoroutine(RaedWord());
                StartCoroutine(SucsessWord());
            }
            else
            {
                rightClicks = (rightClicks + 1) % letters.Length;

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

        for (int i = 0; i < nikud.Length; i++)
        {
            audioSource.clip = nikudUI.ListToRead[i];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);

        }

    }

}
