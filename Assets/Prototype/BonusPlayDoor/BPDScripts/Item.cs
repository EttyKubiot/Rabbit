using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject emmiter;
    [SerializeField] private GameObject bubble;
    [SerializeField] private GameObject player;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Explode()
    {
        Instantiate(emmiter, transform.position, transform.rotation);
        Debug.Log(gameObject);


        GameObject newBullet = Instantiate(bubble, player.transform.position + new Vector3(2, 0, 0), transform.rotation);
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
       

    }
}
