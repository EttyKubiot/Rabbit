using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Paint : MonoBehaviour
{

    public Transform baceDot;
    public static string tool;
    public static Material color;
    public GameObject dot;
    private Camera camera;
    private bool drawNow;
    //[SerializeField] private Image rawImage;
    private void Start()
    {
        camera = Camera.main;
        //Cursor.visible = false;
        drawNow = false;
    }

    private void Update()
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 1));
       

        if (Input.GetMouseButton(0)  && tool == "brush")
        {
            Instantiate(baceDot, mousePosition, baceDot.rotation);
            dot.gameObject.GetComponent<Renderer>().material = color;
           
        }
    }

   

    public void OnClickGoToStore()
    {
        SceneManager.LoadScene(3);

    }

}
