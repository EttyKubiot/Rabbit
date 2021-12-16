using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int score;

    private int health = 0;

    //public UnityAction OnAllItemCollected;
    public UnityAction<int> OnScoreChanged;
    public UnityAction<int> OnWrongClick;
    public UnityAction OnHealseDone;

    //public UnityAction OnPlayerDeath;



    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            OnScoreChanged?.Invoke(score);

            //if (itemsCollected >= maxItems)
            //{
            //    OnAllItemCollected?.Invoke();
            //}
            //else
            //{
            //    OnItemCollected?.Invoke(itemsCollected);
            //}
        }
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnWrongClick?.Invoke(health);
            if (health >= 3)
            {
                OnHealseDone?.Invoke();
                Debug.Log("game over");
            }

        }
    }
}
