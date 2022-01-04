using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgBook : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private Image imageChange;
    [SerializeField] private Image imageColor;
    [SerializeField] private Toggle toggle;
    [SerializeField] private Sprite[] PicturesColoring;
    [SerializeField] private Texture2D[] PicturesColoringjy;



    private int numPicture = 0;
    public void OnClickBook()
    {
        image.gameObject.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        numPicture = (numPicture + 1) % PicturesColoring.Length;

        imageChange.sprite = PicturesColoring[numPicture];
    }
    public void OnClickRightArrow(Button LeftArrow)
    {
        if (numPicture >= 1)
        {
            numPicture--;
        }
        //else
        //{
        //   LeftArrow.image = null;
        //}
        print(numPicture);
        imageChange.sprite = PicturesColoring[numPicture];
    }

    public void OnClickToggle()
    {
        
        if (toggle.isOn)
        {
            StartCoroutine(ChoosePicture());
        }

        else
        {
            return;
        }
    }

    private IEnumerator ChoosePicture()
    {
        ////imageColor. = PicturesColoring[numPicture];
        //imageColor.texture = PicturesColoringjy[numPicture];
        imageColor.sprite = PicturesColoring[numPicture];

        yield return new WaitForSeconds(2f);

        image.gameObject.SetActive(false);
        toggle.isOn = false;
    }
}
