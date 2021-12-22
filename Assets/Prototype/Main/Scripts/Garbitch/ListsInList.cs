using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListsInList : MonoBehaviour
{
  
    public List<int> letters = new List<int>();
    public List<int> nikud = new List<int>();

    public Dictionary<int, int> dictWord1 = new Dictionary<int, int>();
    public Dictionary<int, int> dictWord2 = new Dictionary<int, int>();
    public Dictionary<int, int> dictWord3 = new Dictionary<int, int>();

    public List<Dictionary<int, int>> dictWords  = new List<Dictionary<int, int>>();

    //public List<List<Dictionary<int, int>>> allWords = new List<List<Dictionary<int, int>>>();


    private void Start()
    {
        
        dictWord1.Add(0, 0);
        dictWord1.Add(1, 1);
        dictWord1.Add(2, 2);

        dictWord2.Add(1, 1);
        dictWord2.Add(2, 2);
        dictWord2.Add(0, 0);

        dictWord2.Add(2, 2);
        dictWord2.Add(0, 0);
        dictWord2.Add(1, 1);

        dictWords.Add(dictWord1);
        dictWords.Add(dictWord2);
        dictWords.Add(dictWord3);


        //allWords.Add(dictWords);

    }
}











