using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{

    public Transform baceDot;
    public static string tool;
    public static Material color;
    public GameObject dot;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        //Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1));


        if (Input.GetMouseButton(0) && tool == "brush")
        {
            Instantiate(baceDot, mousePosition, baceDot.rotation);
            dot.gameObject.GetComponent<Renderer>().material = color;
        }
    }

}
