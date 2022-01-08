using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField] private InputField inputField;
   

    public string myName;
   
    public void onPlay()
    {
        PlayerPrefs.GetString("name");
      
        SceneManager.LoadScene(1);
    }

 
  

    public void AddPlayerName()
    {
        myName = inputField.text;
       
        PlayerPrefs.SetString("name", myName);
       



    }

}
