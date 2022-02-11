using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolControler : MonoBehaviour
{
    [SerializeField] private GameObject symbols;
    private enum ToolType
    {
        eraser,
        brush,
        symbol
    }

    [SerializeField]
    private ToolType toolType;

    private void Start()
    {
        toolType = ToolType.brush;
    }

    private void OnMouseDown()
    {
        if (toolType == ToolType.eraser )
        {
            Paint.tool= "eraser";
            Debug.Log(Paint.tool);
        }

        if (toolType == ToolType.brush)
        {
            StartCoroutine(WaitToDraw());
        }

        if (toolType == ToolType.symbol)
        {
            symbols.gameObject.SetActive(true);
        }


    }

    private IEnumerator WaitToDraw()
    {
        yield return new WaitForSeconds(1f);
        Paint.tool = "brush";
    }

    public void OnClickSymbols()
    {
        symbols.gameObject.SetActive(true);
    }
}
