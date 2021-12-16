using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        Cursor.visible = false;
    }

    private void Update()
    {

        transform.position = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1.5f));


    }
}
