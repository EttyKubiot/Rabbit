using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NikudButtons : MonoBehaviour
{
    public Button[] nikud;
    public GameObject[] nikudArrays;
    public int indexNikudCliced;

    public bool IsClicked;


    Dictionary<Button, GameObject> dict = new Dictionary<Button, GameObject>();
    void Start()
    {


        for (int i = 0; i < nikud.Length; i++)
        {
            dict.Add(nikud[i], nikudArrays[i]);

            int cacheIndex = i;

            nikud[i].onClick.AddListener(() => buttonCallBack( nikudArrays[cacheIndex], cacheIndex));

        }
    }

  
    public void buttonCallBack( GameObject nikudArrayActiv, int index) 
    {

       
        indexNikudCliced = index;

        IsClicked = true;
        

        Debug.Log("index nikud" + index);
        Debug.Log(nikudArrayActiv);

        nikudArrayActiv.GetComponent<AudioSource>().clip = nikudArrayActiv.GetComponent<TypeNikudButton>().AudioClipsPlaying;
        nikudArrayActiv.GetComponent<AudioSource>().Play();


    }

   
    public int IndexNikudCliced
    {
        get { return indexNikudCliced; }
       
    }
}
