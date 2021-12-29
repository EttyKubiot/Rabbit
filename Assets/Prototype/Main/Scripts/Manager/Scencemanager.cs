using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scencemanager : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    private void Start()
    {
        gameManager.OnHealseDone += LoadGameOverScence;

    }

    public void LoadGameOverScence()
    {
        SceneManager.LoadScene(2);
    }
}
