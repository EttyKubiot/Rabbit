using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class color : MonoBehaviour
{

    [SerializeField] private Button[] buttons;
    public Material[] material;

    private Dictionary<Button, Material> dict = new Dictionary<Button, Material>();

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            dict.Add(buttons[i], material[i]);

            int index = i;
            buttons[i].onClick.AddListener(() => buttonCallBack(buttons[index], material[index], index));

        }
    }

    private void buttonCallBack(Button buttonCliced, Material audioClipsPlaying, int index)
    {


    }

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Paint.color = this.GetComponent<Renderer>().material;
        Debug.Log(Paint.color);
    }

    public void ChangeButton()
    {
        Paint.color = this.GetComponent<Renderer>().material;
        Debug.Log(Paint.color);
    }




}
