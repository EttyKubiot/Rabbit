using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoteController : MonoBehaviour
{

    private void OnMouseOver()

    {
        if (Paint.tool == "eraser")
        {
            Destroy(gameObject);
        }

    }

    //private void OnMouseDown()
    //{
    //   if ( Paint.tool == "eraser") 
    //   {
    //        Destroy(gameObject);
    //   }

    //}
}
