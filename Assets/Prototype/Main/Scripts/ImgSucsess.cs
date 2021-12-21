using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImgSucsess : MonoBehaviour
{
    
    public int[] letters;
    public int[] nikud;

    private int letterPress;

    [SerializeField] private TypeNikudButton typeNikudButton;

    [SerializeField] private NikudButtons nikudButtons;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private Image picture;

    [SerializeField] private Sprite [] spriteToChangeItTo;

    [SerializeField] private int indexSprite = 0;
    //private ListsInList listsInList;

    private void Start()
    {
        //listsInList = GetComponent<ListsInList>();
        //typeNikudButton = GetComponent<TypeNikudButton>();
          letterPress = 0;

        picture.sprite = spriteToChangeItTo[indexSprite];
        
     }

    private void Update()
    {
       if (typeNikudButton.IsClicked == true)
       {
            AfterClick();
            typeNikudButton.IsClicked = false;
            
       }

      
    }

   
            public void AfterClick()
    {
        if (letters[letterPress] == typeNikudButton.IndexButtonCliced && nikud[letterPress] == nikudButtons.IndexNikudCliced)
        {
            Debug.Log("sucsess");

            if (letterPress + 2 <= letters.Length)
            {
                letterPress++;

            }

            else
            {
                letterPress = 0;
                gameManager.Health = 0;
                Debug.Log("sucsess word");
                gameManager.Score += 10;
               
                indexSprite++;
                picture.gameObject.GetComponent<Image>().sprite = spriteToChangeItTo[indexSprite];
            }
        }

        else
        {
            Debug.Log("Error");
            gameManager.Health++;
        }

        //listsInList.dictWords.dictWord1.letters 
        //if (letters[letterPress] == typeNikudButton.IndexButtonCliced && nikud[letterPress] == nikudButtons.IndexNikudCliced)
        //{
        //    Debug.Log("sucsess");

        //    if (letterPress + 2 <= letters.Length)
        //    {
        //        letterPress++;

        //    }

        //    else
        //    {
        //        letterPress = 0;
        //        Debug.Log("sucsess word");
        //    }
        //}

        //else
        //{
        //    Debug.Log("Error");
        //}




    }

}





