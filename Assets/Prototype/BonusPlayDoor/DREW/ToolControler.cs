using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolControler : MonoBehaviour
{
    private enum ToolType
    {
        eraser,
        brush
    }

    [SerializeField]
    private ToolType toolType;

    private void OnMouseDown()
    {
        if (toolType == ToolType.eraser )
        {
            Paint.tool= "eraser";
            Debug.Log(Paint.tool);
        }

        if (toolType == ToolType.brush)
        {
            Paint.tool = "brush";
        }

    }
}
