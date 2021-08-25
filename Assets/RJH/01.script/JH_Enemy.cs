using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Enemy : MonoBehaviour
{
    public Animator anim;
    public BoxCollider Attackbox;
    public bool isChase;
    public bool isAttack;

    public enum State
    {
        Idle,//����
        Chase,//����
        Attack,//����
        Dead,//���

    }

    public enum Enemy { A, B, C, D}

    public State enemyState = State.Idle;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    
    
    }

    void Targettign()
    {
        float targetRadius = 1.5f;
        float targetRange = 2;

        RaycastHit[] RayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));

        if(RayHits.Length>0 )
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isChase = false;
        isAttack = true;
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(0.5f);
        Attackbox.enabled = true;

        yield return new WaitForSeconds(1f);
        Attackbox.enabled = false;

        isChase = true;
        isAttack = false;
        anim.SetBool("Attack", false);

    }
}
