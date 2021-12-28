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
    private bool nikudPrinted;
    private int indexCorectLetterClick;

    [SerializeField] private Image picture;
    [SerializeField] private AudioClip[] sounds;
    [SerializeField] private ParticleSystem particles;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private NikudUI nikudUI;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private WordData[] words;

    [SerializeField] private bool readWord;
    [SerializeField] private Animator animator;
   public int RightClicks => rightClicks;
    public bool ReadWord => readWord;
    private void Start()
    {
        wordsIndex = 0;
        rightClicks = 0;
        corectLetterClick = false;
        corectNickudClick = false;
        gameManager.OnClickKey += CheckIfClickLetterCorrect;
        gameManager.OnClickNikudKey += CheckIfClickNikudCorrect;
    }


    private void CheckIfClickLetterCorrect(int indexButton)
    {
        if(nikudPrinted == true)
        {
            audioSource.clip = nikudUI.AudioNikudClicked[indexButton];
            audioSource.Play();
        }

        if (words[wordsIndex].nikud[words[wordsIndex].nikud.Length - 1] == 1 && rightClicks == words[wordsIndex].letters.Length - 1 && nikudPrinted == false)
        {
            Debug.Log("lasst nikud shva");
            corectNickudClick = true;
            gameManager.lasstNikudShva?.Invoke();
        }

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

    private void CheckIfClickNikudCorrect(int indexNikudButton)
    {
        nikudPrinted = true;

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

    private void Currect()
    {

        if (corectLetterClick == true && corectNickudClick == true) 
        {
            corectLetterClick = false;
            corectNickudClick = false;
            nikudPrinted = false;

            nikudUI.ListToRead.Add(nikudUI.AudioNikudClicked[indexCorectLetterClick]);

            if (rightClicks + 1 >= words[wordsIndex].letters.Length)
            {
                Debug.Log("sucsess word");
               
                gameManager.Score += 10;
                animator.SetBool("Scale", true);
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
        readWord = true;
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
        readWord = false;
    }


    private IEnumerator PlaySound(int intSound)
    {
        yield return new WaitForSeconds(nikudUI.AudioNikudClicked[indexCorectLetterClick].length + 0.1f);
        audioSource.clip = sounds[intSound];
        audioSource.Play();
        animator.SetBool("Scale", false);

    }

}
