using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPort : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    [SerializeField] GameObject boss;
    [SerializeField] int score;
    private Camera _mainCamera;
    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();
        SetNextEnemy();
    }

    void SetNextEnemy()
    {
        float interval = Random.Range(2f, 6f);
        Invoke("GenerateEnemy", interval);
    }

    //敵を生成する関数
    void Update()
    {
        Debug.Log(GameSceneManager.Score);
        if (GameSceneManager.Score >= score)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                EnemyList[i].SetActive(false);
            }
            Debug.Log(GameSceneManager.Score);
            
            Invoke("SetBossActive", 5f);
                
            //StartCoroutine("BossSetActive");
            //if(boss == null)
            //{
            //    SceneLoader.Destroy(boss);
            //}
                //boss.SetActive(true);
            //}
        }
    }

    void SetBossActive()
    {
        
        if(boss != null)
            boss.SetActive(true);
        else
            boss = null;
    }
    IEnumerator BossSetActive()
    {
        Debug.Log("Test");
        yield return new WaitForSeconds(8.0f);
        boss.SetActive(true);

    }



    private Vector3 getScreenTopLeft()
    {
        // 画面の左上を取得
        Vector3 topLeft = _mainCamera.ScreenToWorldPoint(Vector3.zero);
        // 上下反転させる
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        return topLeft;
    }

    private Vector3 getScreenBottomRight()
    {
        // 画面の右下を取得
        Vector3 bottomRight = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        // 上下反転させる
        bottomRight.Scale(new Vector3(1f, -1f, 1f));
        return bottomRight;
    }
    void GenerateEnemy()
    {
        int enemyindex = Random.Range(0, EnemyList.Count);
        GameObject enemy = Instantiate(EnemyList[enemyindex]);
        enemy.transform.position = this.transform.position;

        float x = Random.Range(getScreenTopLeft().x,getScreenBottomRight().x);
        Vector2 pos = enemy.transform.position;
        pos.x += x;
        enemy.transform.position = pos;
        //生成した敵の位置を、このEnemyPortの位置に調整
        SetNextEnemy();
    }
}
