using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    AudioSource BulletSE;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] List<GameObject> EnemyPortList = new List<GameObject>();

    [SerializeField] GameSceneManager mygameManager;
    public static float healthAmount = 2.1f;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 2.1f;
        InvokeRepeating("ShootS", 0f, 1f);
        BulletSE = GetComponent<AudioSource>();
        for (int i = 0; i < EnemyPortList.Count; i++)
        {
            EnemyPortList[i].SetActive(true);
        }
        //GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        //透明化
        //GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.001f);   
        //マウスに合わせて飛行機が横に移動
        transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
    }
    void ShootS()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, 200f));

        BulletSE.Play();
    }
    void ShootR()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(150f, 200f));
    }
    void ShootL()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(-150f, 200f));
    }
    void TripleShoot()
    {
        ShootS();
        ShootR();
        ShootL();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        healthAmount -= 0.7f;

        if (healthAmount <= 0)
        {
            mygameManager.AddScoreToText();

            Destroy(this.gameObject); //自分自身のオブジェクトを消去
            for (int i = 0; i < EnemyPortList.Count; i++)
            {
                EnemyPortList[i].SetActive(false);
            }

        }
      

        //Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }

}
