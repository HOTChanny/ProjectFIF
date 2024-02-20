using UnityEngine;

public class OnKeyPress_Move : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float speed = 3;
    public float jumppower = 8;

    float vx = 0;
    bool pushFlag = false;
    bool jumpFlag = false;
    bool groundFlag = false;

    void Start()
    {

    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // 키보드에서 손을 뗐을 때 완전 stop -->멈출 때 속도 
    private void Update() //즉각적인 키 입력 ,단발적인 키 입력
    {
        if (Input.GetButtonUp("Horizontal"))//버튼에서 손 뗏을 때 
        {

            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //방향 전환
        if (Input.GetButtonDown("Horizontal"))
        {
            //기본값은 false
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //애니메이션

        if (rigid.velocity.normalized.x == 0)
        {
            //횡 이동 단위 값이 0 (즉 멈춘거)
            anim.SetBool("IsWalking", false);

        }
        else
        {
            anim.SetBool("IsWalking", true);
        }

    }
}