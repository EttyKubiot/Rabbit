using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BonusUI : MonoBehaviour
{
    [SerializeField] private Text bonusName;
    [SerializeField] private Text bonusCost;
   
    // Start is called before the first frame update

    public void UpdateDisplayUI(BonusData bonusdData)
    {
        bonusName.text = bonusdData.BonusName;
        bonusCost.text = bonusdData.BonusCost;

    }


    public void onPlay1()
    {
        SceneManager.LoadScene(3);
    }

    public void onPlay2()
    {
        SceneManager.LoadScene(4);
    }

    public void onPlay3()
    {
        SceneManager.LoadScene(5);

    }

    public void onPlay4()
    {
        SceneManager.LoadScene(6);
    }
}
