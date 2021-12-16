using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    private const string HORIZPNTAL_AXIS = "Horizontal";
    private float hInput;
    private bool acceptInput = true;

    [SerializeField]
    private float movePositiveRange = 2.93f;
    [SerializeField]
    private float moveNegativeRange = -2.85f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 100;
    private bool canShoot = false;
  


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!acceptInput)
        {
            return;
        }


        hInput = Input.GetAxis(HORIZPNTAL_AXIS) * moveSpeed;
        Vector3 newPosition = transform.position;
        newPosition.x += hInput * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, moveNegativeRange, movePositiveRange);
        transform.position = newPosition;

        if (Input.GetMouseButtonDown(0))
        {
            canShoot = true;
        }

    }

    private void FixedUpdate()
    {
        

        if (canShoot)
        {
            canShoot = false;
            GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(-8, -10, 8), transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            
        }

       
    }
}
