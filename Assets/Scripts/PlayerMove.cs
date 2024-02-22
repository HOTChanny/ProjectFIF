using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
        
    }

    void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            //Ű ���� ��
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        //������ȯ
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //�ִϸ��̼� ��ȯ(���ֱ�<>�ȱ�)
        if (Mathf.Abs(rigid.velocity.x) < 0.48) // �ӵ��� �󸶳� �������� �� ����� �ٲ����
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        //�ִϸ��̼� ��ȯ - ����
        if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        //�ִϸ��̼� ��ȯ-���� : qŰ�� ������ �� ���� �ִϸ��̼��� ����ǰ� ���� �ʴٸ� Ʈ���� ����
        if (Input.GetKeyDown(KeyCode.Q) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            anim.SetTrigger("attack");
            gameObject.layer = 12;
            Invoke("OnAttack", 1);
        }

        
    }
    void OnAttack()
    {
        gameObject.layer = 10;
    }


    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if(rigid.velocity.x > maxSpeed) // Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1)) // Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //RayCast>> ������Ʈ �˻��� ���� Ray�� ��� ���, �ٴڰ���
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.6f)
                    anim.SetBool("isJumping", false);
            }
        }
        
    }
     void OnCollisionEnter2D(Collision2D collision) // �÷��̾� �ǰ� �̺�Ʈ
    {
        if(collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
        }
        
    }
    void OnDamaged(Vector2 targetPos) // �¾��� ��, ���̾� �ٲ㼭 �����ϱ�
    {
        gameObject.layer = 11;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*7, ForceMode2D.Impulse);

        //�ǰ� �ִϸ��̼�
        anim.SetTrigger("doDamaged");

        Invoke("OffDamaged", 2);
    }

    void OffDamaged() // �ǰ� �� 2�� �Ŀ� ���̾� �������
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
