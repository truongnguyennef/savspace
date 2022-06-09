using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text StageTxt;
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        StageTxt.text = SceneManager.GetActiveScene().name;
    }
}
