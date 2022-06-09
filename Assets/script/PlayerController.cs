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
    [SerializeField] public float healthdown;
    private Camera _mainCamera;
    public static float healthAmount = 0.2f;
    public float fMoveSpeed = 0.01f;
    //public float mouseSensitivityX = 1;
    //public float mouseSensitivityY = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();

        healthAmount = 0.2f;
        InvokeRepeating("ShootS", 0f, 0.1f);
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
        transform.position = new Vector2(
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -2.6f, 2.6f),
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -4.5f, 3.8f));

        Mathf.Clamp(transform.position.y, -4.5f, 3.8f);


        // 横(Ⅹ)方向の入力
        var fHorizontalInput = Input.GetAxisRaw("Horizontal");
        // 縦(Ｙ)方向の入力
        var  fVerticalInput = Input.GetAxis("Vertical");

        // 位置を更新
        var velocity = new Vector3(
            fHorizontalInput, fVerticalInput) * fMoveSpeed;
        //var velocity = new Vector3(fHorizontalInput, fVerticalInput) * fMoveSpeed;
        transform.localPosition += velocity;

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
        healthAmount -= healthdown;
        Debug.Log("Player health 残り" + healthAmount);

        if (healthAmount <= 0)
        {
            mygameManager.AddScoreToText();

            Destroy(this.gameObject); //自分自身のオブジェクトを消去
            for (int i = 0; i < EnemyPortList.Count; i++)
            {
                EnemyPortList[i].SetActive(false);
            }

        }

    }
    //public static Vector2 m_moveLimit = new Vector2(4f, 3f);
    //public static Vector3 ClampPosition( Vector3 posion)
    //{
    //    //return new Vector3(
    //    //    Mathf.Clamp(posion.x, getS),


    //    //    );
    //}

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
}
