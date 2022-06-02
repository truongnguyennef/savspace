using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    //[SerializeField] Boss boss;
    public void Load(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(boss == null)
        //{
        //    Debug.Log("a");
        //    SceneManager.LoadScene(2);
        //}
    }
}
