using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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




}
