using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float ActiveTime = 5f;

    [SerializeField] public float speed = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] GameObject boss;
    public static float health = 1.5f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        health = 1.5f;

        Invoke("DestroyMyself", ActiveTime);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
       
        InvokeRepeating("Shoot", 0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //void DestroyMyself()
    //{
    //    GameObject explosion = Instantiate(ExplosionEffect);
    //    explosion.transform.position = this.transform.position;
    //    Destroy(this.gameObject);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        health -= 0.5f;
        Debug.Log("heal残り"+　health);
        if (health <= 0)
        {
            //GameSceneManager.Score++;
            //Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        //今からここを埋めていくよ
        for (int i = -100; i <= 100; i += 50)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
            bulletRigid.AddForce(new Vector2(i, -100f));
        }
    }
}
