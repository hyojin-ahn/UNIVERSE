using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    /* PlayerMove */
    private float h;
    private float v;
    private float r;
    public CharacterController cc;

    /* Speed */
    [Range(5.0f, 50.0f)]
    public float moveSpeed = 8.0f;
    [Range(5.0f, 50.0f)]
    public float rotSpeed = 40.0f;

    /* Animation */ //펫에 끌어와서 사용하기 위해 정적 변수 선언
    private Animator anim;
    /* Move */ private bool isMove = false;
    /* Attack */ private  bool isAttack = false;
    /* Death */ private bool isDie = false;
    //public float dieDelay = 0.5f;


    /* HP */
    private readonly float iniHp = 100.0f;
    public float currHp;


    private void Awake()
    {
        isMove = false;
        isAttack = false;
        isDie = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();

        /* Hp ini */
        currHp = iniHp;

    }

    // Update is called once per frame
    void Update()
    {
        /* Player Move */
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("MouseX");

        Vector3 dir = ((Vector3.right * h) + (Vector3.forward * v));
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(dir.normalized * rotSpeed * r * Time.deltaTime);

        if(v < 0)
        {
            h = 0;
        }

        PlayerAnim();
    }

    /* Animation */
    void PlayerAnim()
    {
        if (v < 0.0f)
        {
            if (isMove == false)
            {
                anim.SetTrigger("WalkB");
                isMove = true;

            }
        }
        else if (v > 0.0f)
        {
            if (isMove == false)
            {
                anim.SetTrigger("WalkF");
                isMove = true;
            }
        }
        else if (h < 0.0f)
        {
            if (isMove == false)
            {
                anim.SetTrigger("WalkL");
                isMove = true;
            }
        }
        else if (h > 0.0f)
        {
            if (isMove == false)
            {
                anim.SetTrigger("WalkR");
                isMove = true;
            }
        }
        else
        {
            if (isMove == false)
            {
                anim.SetBool("Idle", true);

            }
        }
    }

    /* Attack Mode */
    void PlayerAttack()
    {
        
    }

    /* Die */
    void PlayerDie()
    {
        //만약 플레이어가 죽었다면
        if (isDie == true)
        {
            Debug.Log("Player Die!");

            anim.SetTrigger("Die");
        }

        // 코루틴 함수 ( WaitforSecond )
        // gameOver씬으로 전환
    }
}
