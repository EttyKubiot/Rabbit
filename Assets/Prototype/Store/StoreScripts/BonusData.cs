using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sword Data", menuName = "Bonus Data", order = 51)]

public class BonusData : ScriptableObject
{
    [SerializeField] private string bonusName;
    [SerializeField] private string bonusCost;
    // Start is called before the first frame update
    public string BonusName => bonusName;
    public string BonusCost => bonusCost;
}
