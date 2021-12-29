using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator animatorScore;
    [SerializeField] private Animator animatorHealth;
    
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager.OnScoreChanged += FleshScore;
        gameManager.OnWrongClick += FleshHealthBar;
    }

    private void FleshScore(int scoreee)
    {
        animatorScore.SetBool("ScaleScore", true);

        StartCoroutine(ResetAnim(animatorScore, "ScaleScore"));
    }

    private void FleshHealthBar(int health)
    {
        animatorHealth.SetBool("GrowBar", true);
        
        StartCoroutine(ResetAnim(animatorHealth, "GrowBar"));
    }

    private IEnumerator ResetAnim(Animator curentanimator, string boolName)
    {
        yield return new WaitForSeconds(1f);
        curentanimator.SetBool(boolName , false);
    }
    


}
