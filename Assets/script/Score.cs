using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text ScoreTxt;
    int score;
    //public static String score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //score = GameSceneManager.Score.ToString();
        ScoreTxt.text = "Score:" + GameSceneManager.Score.ToString();

        
        if(SceneManager.GetActiveScene().name == "Stage 2")
        {
            Debug.Log("Stage 22222");

            //ScoreTxt.text = "Score:" + GameSceneManager.Score.ToString();
            score = PlayerPrefs.GetInt("SCORE");


            ScoreTxt.text = "Score:" + (score + GameSceneManager.Score).ToString();
            Debug.Log(score);
        }

    }

}
