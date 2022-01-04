using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePhoto : MonoBehaviour
{
    private Texture2D tex2D  = null;

    private List<Texture2D> tex2Dd = new List<Texture2D>();
    private List<Sprite> SpriteLJG = new List<Sprite>();

    public Image ShowImg;
    public RawImage photo;

    private int numPicture = 0;


    public void OnClickCamara()
    {
        StartCoroutine(CaptureScreen());
    }

    //public void OnClickLibrery()
    //{
    //    StartCoroutine(CaptureScreen());
    //}

    IEnumerator CaptureScreen()
    {
        yield return new WaitForEndOfFrame();
        if (tex2D == null) 
        {

            tex2Dd.Add(new Texture2D(/*Screen.width*/1200, /*Screen.height*/675, TextureFormat.RGB24, false));
            tex2Dd[numPicture].ReadPixels(new Rect(0, 350, 1200, /*Screen.height*/ 675), 0, 0, false);
            tex2Dd[numPicture].Apply();

            SpriteLJG.Add(ConvertToSprite(tex2Dd[numPicture]));
            ShowImg.sprite = SpriteLJG[numPicture];
            numPicture++;
        }

    }

    public Sprite ConvertToSprite(Texture2D textureesty)
    {
        return Sprite.Create(textureesty, new Rect(0, 0, textureesty.width, textureesty.height), Vector2.zero);
    }


    public void OnClickImage()
    {
        photo.gameObject.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        numPicture = (numPicture + 1) % SpriteLJG.Count;

        ShowImg.sprite = SpriteLJG[numPicture];
    }
    public void OnClickRightArrow()
    {
        if (numPicture >= 1)
        {
            numPicture--;
        }
        print(numPicture);
        ShowImg.sprite = SpriteLJG[numPicture];
    }
}
