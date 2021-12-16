using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private AudioSource audioSource;
    private Camera camera;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }



    }

    private void Fire()
    {

        audioSource.Play();

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);


        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            Item item = raycastHit.rigidbody.gameObject.GetComponent<Item>();

            if (item)
            {
                item.Explode();

            }


            Debug.DrawRay(transform.position, transform.forward, Color.green);

        }
    }
}
