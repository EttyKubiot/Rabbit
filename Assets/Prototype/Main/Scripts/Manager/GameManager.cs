using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int score;
    private int health = 0;

    public UnityAction<int> OnScoreChanged;
    public UnityAction<int> OnWrongClick;
    public UnityAction OnHealseDone;

    public UnityAction<int> OnClickKey;
    public UnityAction<int> OnClickNikudKey;
    public UnityAction OnSucsessWord;
    public UnityAction lastNikudShva;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            OnScoreChanged?.Invoke(score);
        }
    }

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnWrongClick?.Invoke(health);
            if (health >= 5)
            {
                OnHealseDone?.Invoke();
                Debug.Log("game over");
            }

        }
    }
}
