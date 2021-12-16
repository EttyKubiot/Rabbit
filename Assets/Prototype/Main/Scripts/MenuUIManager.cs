using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuUIManager : MonoBehaviour
{
    public Animator contentPanel;
    public Animator gearImage;

   
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
}
