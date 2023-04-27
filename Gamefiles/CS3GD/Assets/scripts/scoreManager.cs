using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class scoreManager : MonoBehaviour
{
    
    public TMP_Text killScore;
    int score = 0;

    void Start()
    {
        killScore.text = score.ToString() + "points";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
