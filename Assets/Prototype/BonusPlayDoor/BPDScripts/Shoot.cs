using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private AudioSource audioSource;
    private Camera camera;
    [SerializeField] Animator animator;

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

        Ray ray = new Ray(transform.position, Vector3.right);
        Debug.DrawRay(transform.position, Vector3.right * 1000);

        RaycastHit raycastHit = new RaycastHit();

        if (Physics.Raycast(ray, out raycastHit, 1000))
        {
            Item item = raycastHit.rigidbody.gameObject.GetComponent<Item>();

            if (item)
            {
                item.Explode();

            }


            animator.SetBool("Shoot", true);

        }
    }
}
