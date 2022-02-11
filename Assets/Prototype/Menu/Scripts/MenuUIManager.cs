using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuUIManager : MonoBehaviour
{
    public Animator contentPanel;
    public Animator gearImage;
    [SerializeField] private GameManager gameManager;
    private int playerPrefs;
    private void Awake()
    {
        Cursor.visible = true;
        playerPrefs = PlayerPrefs.GetInt("Score", gameManager.Score);
    }
   
    public void ToggleMenu()
    {
        int hide = contentPanel.GetInteger("isHide");
        
        contentPanel.SetInteger("isHide", 2);
        gearImage.SetInteger("isHide", 2);
        if (hide == 2)
        {
            contentPanel.SetInteger("isHide", 1);
            gearImage.SetInteger("isHide", 1);
        }

       
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    



    public void ExitGame()
    {
        Application.Quit();
    }

}
