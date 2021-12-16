using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] prefab;
   
    [SerializeField]
    private float minForce;
    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float minTime = 1;
    [SerializeField]
    private float maxTime = 3;
    [SerializeField]
    private float speed = 0.25f;
    [SerializeField]
    private float minAngel = -60;
    [SerializeField]
    private float maxAngel = 60;
    private float moreSpeed;
    private float realTime;



    // Start is called before the first frame update
    void Start()
    {
        realTime = 1;
        StartCoroutine(ThrowLoop());

        StartCoroutine(Harder());

    }

    private IEnumerator ThrowLoop()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime * realTime));

            ThrowFruit();

        }


    }
    public void ThrowFruit()
    {

        transform.parent.localEulerAngles = new Vector3(0, 0, Random.Range(minAngel, maxAngel));
        GameObject go = Instantiate(prefab[Random.Range(0, prefab.Length)], transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddForce(transform.forward * Random.Range(minForce, maxForce));


    }

    private IEnumerator Harder()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            realTime -= 0.2f;
           
           

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Lives -= 1;
          
           Debug.Log("Critical hit!");

           //How to Create a collision with Particle System???
          //After 20  collision close door
        }
    }
}
