using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurectClicks : MonoBehaviour
{
    public int[] letters;
    public int[] nikud;

    [SerializeField] private GameManager gameManager;

    private int letterPress;
    private bool corectButtonClick;
    private bool corectNickudClick;

    public int LetterPress => letterPress;
    public bool CorectButtonClick => corectButtonClick;

    private void Start()
    {
        letterPress = 0;
        corectButtonClick = false;
        corectNickudClick = false;
        gameManager.OnClickKey += CheckIfClickCorrect;
        gameManager.OnClickNikudKey += CheckIfClickNikudCorrect;
    }


    public void CheckIfClickCorrect(int indexButton)
    {
        if (letters[letterPress] == indexButton)
        {
            Debug.Log("sucsess");
            corectButtonClick = true;
            Currect();
        }
        else
        {
            Debug.Log("Error");
            corectButtonClick = false;
            gameManager.Health++;
        }
    }

    public void CheckIfClickNikudCorrect(int indexNikudButton)
    {
        if (nikud[letterPress] == indexNikudButton)
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

        if (corectButtonClick == true && corectNickudClick == true) 
        {
            corectButtonClick = false;
            corectNickudClick = false;
            if (letterPress + 1 >= letters.Length)
            {
                Debug.Log("sucsess word");
                gameManager.Score += 10;
                letterPress = 0;
                gameManager.Health = 0;
                
                StartCoroutine(RisitAll());
            }
            else
            {
                letterPress = (letterPress + 1) % letters.Length;
            }
        }

        else
        {
            return;
        }
    }

    private IEnumerator RisitAll()
    {
        yield return new WaitForSeconds(2f);
        gameManager.OnSucsessWord?.Invoke();

    }

}
