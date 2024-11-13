using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private string enemyTag = "Fire";
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    private Animator animator;
    public AudioClip Bonus;
    public AudioClip GruntVoice;
    bool push;
    bool boolLeft;
    bool boolRight;
    AudioSource aud;
    
    public void JumpButtonDown()
    {
        this.rigid2D.AddForce(transform.up * this.jumpForce);
        this.push = true;
    }
    public void JumpButtonPushUp()
    {
        this.push = false;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.aud = GetComponent<AudioSource>();
        this.push = false;
        this.boolLeft = false;
        this.boolRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.push)
        {
            this.boolRight = false;
            this.boolLeft = false;
        }
        /*if (Input.GetMouseButton(0) &&
          this.rigid2D.velocity.y == 0)
        {
           
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }*/
        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) || boolRight) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow) || boolLeft) key = -1;
        //プレイヤーの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
         

        //ジャンプする
        /* if (Input.GetKeyDown(KeyCode.Space))
         {
             this.rigid2D.AddForce(transform.up * this.jumpForce);
         }
         //左右移動
         int key = 0;
         if (Input.GetKey(KeyCode.RightArrow)) key = 1;
         if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
         //プレイヤーの速度
         float speedx = Mathf.Abs(this.rigid2D.velocity.x);
         //スピード制限
         if (speedx < this.maxWalkSpeed)
         {
             this.rigid2D.AddForce(transform.right * key * this.walkForce);
         }

         */
        if (rigid2D.velocity.x > 1)
       {    /* 右方向に動いている */   }
        else if (rigid2D.velocity.x < -1)
        {    /* 左方向に動いている */   }
        else
       {    /* そんなに動いてない */   }

        Vector3 scale = transform.localScale;
        if (rigid2D.velocity.x > 1)      // 右方向に動いている
            scale.x = 2;  // 通常方向(スプライトと同じ右向き)
        else if (rigid2D.velocity.x < -1) // 左方向に動いている
           scale.x = -2; // 反転
         //更新
        transform.localScale = scale;
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    public void LButtonPushUp()
    {
        this.push = false;
    }

    // 左移動ボタン押下時
    public void LButtonPushDown()
    {
        this.boolLeft = true;
        this.push = true;
    }

    // 右移動ボタン離した時
    public void RButtonPushUp()
    {
        this.push = false;
    }

    // 右移動ボタン押下時
    public void RButtonPushDown()
    {
        this.boolRight = true;
        this.push = true;
    }


    void OnCollisionEnter2D(Collision2D collision)//Fireにあたったら
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            aud.PlayOneShot(GruntVoice);
            GameObject director = GameObject.Find("Life");
            director.GetComponent<Life>().DecreaseHp();
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {　　//ダイヤに触れたらクリアシーンに移る
        if(other.gameObject.tag =="goal")
        {
            //GetComponent<AudioSource>().Play();
            aud.PlayOneShot(Bonus);
            Debug.Log("ゴール");
            SceneManager.LoadScene("ClearScene");
        }

        //がいこつに触れたらがいこつが消える
            if (other.gameObject.CompareTag("Skull"))
            {
                aud.PlayOneShot(GruntVoice);
                other.gameObject.SetActive(false);
                GameObject director = GameObject.Find("Life");
                director.GetComponent<Life>().DecreaseHp();
            }
        

    }
    
}
