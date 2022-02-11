using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayerPref : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
    }
}
