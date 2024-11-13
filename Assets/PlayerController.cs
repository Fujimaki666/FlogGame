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
        //���E�ړ�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow) || boolRight) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow) || boolLeft) key = -1;
        //�v���C���[�̑��x
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        //�X�s�[�h����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
         

        //�W�����v����
        /* if (Input.GetKeyDown(KeyCode.Space))
         {
             this.rigid2D.AddForce(transform.up * this.jumpForce);
         }
         //���E�ړ�
         int key = 0;
         if (Input.GetKey(KeyCode.RightArrow)) key = 1;
         if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
         //�v���C���[�̑��x
         float speedx = Mathf.Abs(this.rigid2D.velocity.x);
         //�X�s�[�h����
         if (speedx < this.maxWalkSpeed)
         {
             this.rigid2D.AddForce(transform.right * key * this.walkForce);
         }

         */
        if (rigid2D.velocity.x > 1)
       {    /* �E�����ɓ����Ă��� */   }
        else if (rigid2D.velocity.x < -1)
        {    /* �������ɓ����Ă��� */   }
        else
       {    /* ����Ȃɓ����ĂȂ� */   }

        Vector3 scale = transform.localScale;
        if (rigid2D.velocity.x > 1)      // �E�����ɓ����Ă���
            scale.x = 2;  // �ʏ����(�X�v���C�g�Ɠ����E����)
        else if (rigid2D.velocity.x < -1) // �������ɓ����Ă���
           scale.x = -2; // ���]
         //�X�V
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

    // ���ړ��{�^��������
    public void LButtonPushDown()
    {
        this.boolLeft = true;
        this.push = true;
    }

    // �E�ړ��{�^����������
    public void RButtonPushUp()
    {
        this.push = false;
    }

    // �E�ړ��{�^��������
    public void RButtonPushDown()
    {
        this.boolRight = true;
        this.push = true;
    }


    void OnCollisionEnter2D(Collision2D collision)//Fire�ɂ���������
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            aud.PlayOneShot(GruntVoice);
            GameObject director = GameObject.Find("Life");
            director.GetComponent<Life>().DecreaseHp();
        }
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {�@�@//�_�C���ɐG�ꂽ��N���A�V�[���Ɉڂ�
        if(other.gameObject.tag =="goal")
        {
            //GetComponent<AudioSource>().Play();
            aud.PlayOneShot(Bonus);
            Debug.Log("�S�[��");
            SceneManager.LoadScene("ClearScene");
        }

        //�������ɐG�ꂽ�炪������������
            if (other.gameObject.CompareTag("Skull"))
            {
                aud.PlayOneShot(GruntVoice);
                other.gameObject.SetActive(false);
                GameObject director = GameObject.Find("Life");
                director.GetComponent<Life>().DecreaseHp();
            }
        

    }
    
}
