using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CorrectClicks : MonoBehaviour
{
    [Space(10)]
    [Header("Game progress")]
    private int rightClicks;
    private int indexCorrectLetterClick;
    private bool correctNickudClick;
    private bool correctLetterClick;
    private bool nikudPrinted;
    private bool readingWord;

    [Space(10)]
    [Header("Effects")]
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Image picture;

    [Space(10)]
    [Header("Help")]
    [SerializeField] private Animator glowKeyAnimator;
    [SerializeField] private Animator glowNikudAnimator;

    [Space(10)]
    [Header("Refernces")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private NikudUI nikudUI;
    [SerializeField] private AudioSource audioSource;

    [Space(10)]
    [Header("Word")]
    [SerializeField] private WordData[] words;
    private int wordsIndex;
    
    public int RightClicks => rightClicks;
    public bool ReadingWord => readingWord;
    private void Start()
    {
        wordsIndex = 0;
        rightClicks = 0;
        correctLetterClick = false;
        correctNickudClick = false;
        gameManager.OnClickKey += CheckIfClickLetterCorrect;
        gameManager.OnClickNikudKey += CheckIfClickNikudCorrect;
    }


    private void CheckIfClickLetterCorrect(int indexButton)
    {
        if (nikudPrinted == true) // if nikud Printed before letter
        {
            audioSource.clip = nikudUI.AudioNikudClicked[indexButton];
            audioSource.Play();
        }

        if (words[wordsIndex].nikud[words[wordsIndex].nikud.Length - 1] == 1 
            && rightClicks == words[wordsIndex].letters.Length - 1 && nikudPrinted == false) //if last nikud shva
        {
            Debug.Log("if last nikud shva");
            correctNickudClick = true;
            gameManager.lastNikudShva?.Invoke();
        }

        if (words[wordsIndex].letters[rightClicks] == indexButton)
        {
            Debug.Log("sucsess");
            correctLetterClick = true;
            indexCorrectLetterClick = indexButton;
            Correct();
        }

        else
        {
            Debug.Log("Error");
            correctLetterClick = false;
            gameManager.Health++;
        }

    }

    private void CheckIfClickNikudCorrect(int indexNikudButton)
    {
        nikudPrinted = true;

        if (words[wordsIndex].nikud[rightClicks] == indexNikudButton)
        {
            Debug.Log("sucsessNikud");
            correctNickudClick = true;
            Correct();
        }
        else
        {
            Debug.Log("Error");
            correctNickudClick = false;
            gameManager.Health++;
        }
    }

    private void Correct()
    {

        if (correctLetterClick == true && correctNickudClick == true) 
        {
            correctLetterClick = false;
            correctNickudClick = false;
            nikudPrinted = false;

            nikudUI.ListToRead.Add(nikudUI.AudioNikudClicked[indexCorrectLetterClick]);

            if (rightClicks + 1 >= words[wordsIndex].letters.Length)
            {
                Debug.Log("sucsess word");
               
                gameManager.Score += 10;
                gameManager.Health = 0;
                rightClicks = 0;
                StartCoroutine(PlaySound(1));
                StartCoroutine(SucsessWord());
            }
            else
            {
                rightClicks = (rightClicks + 1) % words[wordsIndex].letters.Length;
                StartCoroutine(PlaySound(0));

            }
        }

        else
        {
            return;
        }
    }

    private IEnumerator SucsessWord()
    {
        particles.Play();
        readingWord = true;

        yield return new WaitForSeconds(2.5f);

        for (int i = 0; i < words[wordsIndex].nikud.Length; i++)
        {
            audioSource.clip = nikudUI.ListToRead[i];
            audioSource.Play();
           
            yield return new WaitForSeconds(audioSource.clip.length);
        }
       
        yield return new WaitForSeconds(1f);
        gameManager.OnSucsessWord?.Invoke();
        wordsIndex = (wordsIndex + 1) % words.Length;
        picture.gameObject.GetComponent<Image>().sprite = words[wordsIndex].wordSprite;
        readingWord = false;
    }


    private IEnumerator PlaySound(int intSound)
    {
        yield return new WaitForSeconds(nikudUI.AudioNikudClicked[indexCorrectLetterClick].length + 0.1f);
        audioSource.clip = sounds[intSound];
        audioSource.Play();
    }

    public void ShowLetter()
    {
        gameManager.Score -= 2;
        glowKeyAnimator.SetInteger("KeyGlow", words[wordsIndex].letters[rightClicks]);
        glowNikudAnimator.SetInteger("GlowNikud", words[wordsIndex].nikud[rightClicks]);

        StartCoroutine(ResetGlow());
    }

    private IEnumerator ResetGlow()
    {
        yield return new WaitForSeconds(1.2f);
        glowNikudAnimator.SetInteger("GlowNikud", 10);
        glowKeyAnimator.SetInteger("KeyGlow", 100);
    }

}
