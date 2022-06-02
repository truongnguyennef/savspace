using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text ScoreTxt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreTxt.text = "Score:" +GameSceneManager.Score.ToString();
    }
}
