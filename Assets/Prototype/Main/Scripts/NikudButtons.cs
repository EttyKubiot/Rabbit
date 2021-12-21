using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NikudButtons : MonoBehaviour
{
    public Button[] nikud;
    public GameObject[] nikudArrays;
    public int indexNikudCliced;


    Dictionary<Button, GameObject> dict = new Dictionary<Button, GameObject>();
    void Start()
    {


        for (int i = 0; i < nikud.Length; i++)
        {
            dict.Add(nikud[i], nikudArrays[i]);

            nikudArrays[i].SetActive(false);
            int cacheIndex = i;

            nikud[i].onClick.AddListener(() => buttonCallBack(/*nikud[cacheIndex],*/ nikudArrays[cacheIndex], cacheIndex));

        }
    }

  
    public void buttonCallBack(/*Button nikudCliced,*/ GameObject nikudArrayActiv, int index) 
    {

        for (int i = 0; i < nikudArrays.Length; i++)
        {

            nikudArrays[i].SetActive(false);

        }

        nikudArrayActiv.SetActive(true);
        indexNikudCliced = index;
        

        Debug.Log("index nikud" + index);
        Debug.Log(nikudArrayActiv);
       

    }

   
    public int IndexNikudCliced
    {
        get { return indexNikudCliced; }
       
    }
}
