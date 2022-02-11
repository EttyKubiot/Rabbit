using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BonusUI : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text bonusName;
    [SerializeField] private Text bonusCost;
    [SerializeField] private Text scoreText;
    private int scoreBuy;
    // Start is called before the first frame update

    public void Start()
    {
        scoreBuy = PlayerPrefs.GetInt("Score", gameManager.Score);
        scoreBuy = PlayerPrefs.GetInt("Score", scoreBuy);
        scoreText.text = scoreBuy.ToString();
    }
    public void UpdateDisplayUI(BonusData bonusdData)
    {
        bonusName.text = bonusdData.BonusName;
        bonusCost.text = bonusdData.BonusCost;

    }


    public void onPlay1()
    {

        scoreBuy -= 40;
        PlayerPrefs.SetInt("Score", scoreBuy);
        PlayerPrefs.Save();
        SceneManager.LoadScene(4);
    }

    //public void onPlay2()
    //{
    //    SceneManager.LoadScene(5);
    //}

    //public void onPlay3()
    //{
    //    SceneManager.LoadScene(6);

    //}

    public void onPlay4()
    {

        scoreBuy -= 50;
        //gameManager.OnScoreChanged?.Invoke( gameManager.Score);
        PlayerPrefs.SetInt("Score", scoreBuy);
        PlayerPrefs.Save();
        SceneManager.LoadScene(5);
    }
}
