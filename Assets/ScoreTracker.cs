using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public static ScoreTracker instance;

    public int score;
    public TMP_Text scoreTMP;

    void Awake() 
    {
        instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        scoreTMP.text = "Score: " + score;
    }
}
