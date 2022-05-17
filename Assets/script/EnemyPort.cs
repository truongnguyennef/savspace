using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPort : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Boss;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
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
        if (GameSceneManager.Score >= 5)
        {
            for (int i = 0; i < EnemyList.Count; i++)
            {
                EnemyList[i].SetActive(false);
            }
            GameObject boss = Instantiate(Enemy);
            boss.transform.position = this.transform.position;
        }
    }
    void GenerateEnemy()
    {
        int enemyindex = Random.Range(0, EnemyList.Count);
        GameObject enemy = Instantiate(EnemyList[enemyindex]);
        enemy.transform.position = this.transform.position;
        //生成した敵の位置を、このEnemyPortの位置に調整
        SetNextEnemy();
    }
}
