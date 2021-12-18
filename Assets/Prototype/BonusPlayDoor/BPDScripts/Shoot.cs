using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    private AudioSource audioSource;
    private Camera camera;
    [SerializeField] GameObject shooter;

    [SerializeField] Animator animator;
    private float lengthClip;
    [SerializeField] private AnimationClip shootClip;

    private int scoreBonus = 0;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private Text text;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        camera = Camera.main;
        lengthClip = shootClip.length;
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
                animator.SetBool("Shoot", true);
                scoreBonus++;
                text.text = scoreBonus.ToString();
                Debug.Log(scoreBonus);
               
                if (scoreBonus == 10)
                {
                    doorAnimator.SetInteger("CloseDoor", 1);
                    Debug.Log("i am ANIMATOR");

                    shooter.SetActive(false);
                }
                StartCoroutine(ReturnAnimation());
            }



        }
    }

    private IEnumerator ReturnAnimation()
    {
        yield return new WaitForSeconds(lengthClip);
        animator.SetBool("Shoot", false);
    }

}
