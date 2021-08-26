using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class JH_ADEnemy : MonoBehaviour
{
    public enum State
    {
        Idle,//정지
        Chase,//추적
        Attack,//공격
        Hit,
        Dead,//사망

    }

    public State currentState = State.Idle;
    public float Enemyspeed; //이동속도
      
    public float attackCoolTime; //다음공격시간
    public float attackTimer; //공격타이머
    public float rotate = 360f;
    public float chaseDistance = 5f; // 추적을 시작할 거리
    public float attackDistance = 2.5f; //  공격시작 거리
    public float reChaseDistance = 3f; //도망시 재추적할거리

    public bool isDead;

    public bool isAttack;
    


    private Transform player;
    
    public NavMeshAgent agent;

    
    public int EnemycurrHp ;
    public int EnemyMaxHP;

    public GameObject bloodFac;
    

    public Animator animator;
    
    
    float currentTime;
    public float idleDelayTime = 0.5f;
    public BoxCollider Attackbox;
    CharacterController cc;
    public float speed = 2;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        EnemycurrHp = EnemyMaxHP;
        
    }
    void Update()
    {
        
     switch(currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Chase:
                ChaseState();
                break;
            case State.Attack:
                AttackState();
                break;
            case State.Hit:
                HitState();
                break;
            case State.Dead:
                DeadState();
                break;
        }
    }
   
            
   
    void IdleState()
    {
        Vector3 dir = player.transform.position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();
        dir.y = 0;

       
        if (distance < chaseDistance)
        {
            currentState = State.Chase;
            animator.SetTrigger("Run");

        }

       
     
    }
    void ChaseState()
    {
            TurnDestination();
            MoveDestination();

        Vector3 dir = player.transform.position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();
        dir.y = 0;
       

        if (distance < attackDistance)
        {
            currentState = State.Attack;
        }

    }
    void AttackState()
    {
            

        float targetRadius = 1.5f;
        float targetRange = 2.5f;
        RaycastHit[] RayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
            if(RayHits.Length>0 && !isAttack)
            {
                StartCoroutine(Attack());
            }

        Vector3 dir = player.transform.position - transform.position;
        float distance = dir.magnitude;
        dir.Normalize();
        dir.y = 0;
        
        if (distance > reChaseDistance)
        {

            currentState = State.Chase;
            animator.SetTrigger("Run");
        }


    }

    IEnumerator Attack()
    {
        isAttack = true;
        int r = Random.Range(0, 3);
        if (r == 0)
        { animator.SetBool("Attack", true); }
        else if (r == 1)
        { animator.SetBool("Attack_02", true); }
        else
        { animator.SetBool("Attack_03", true); }

        yield return new WaitForSeconds(1f);
        Attackbox.enabled = true;

        yield return new WaitForSeconds(1.5f);
        Attackbox.enabled = false;


        isAttack = false;
        animator.SetBool("Attack", false); 
        animator.SetBool("Attack_02", false);
        animator.SetBool("Attack_03", false);

    }

    void HitState()
    {
        
    }
    void DeadState()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
       CreatBloodEffect();
        if(collision.gameObject.name.Contains("Bullet"))
        {

            StopAllCoroutines();
           
            EnemycurrHp -= 20;
            if(EnemycurrHp>0)
            { 
            animator.SetTrigger("Hit");
            }
            
            
            else if (EnemycurrHp <= 0)
            {
                cc.enabled = false;
                currentState = State.Dead;
                animator.SetTrigger("Death");
                Destroy(gameObject, 3f);
                

            }
           
        }

       
    }
    public GameObject FireFac;
    public Transform FirePos;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Pet"))
        {
            EnemycurrHp -= 30;
            animator.SetTrigger("Jump");
            GameObject Fire = Instantiate(FireFac);
            FireFac.transform.position = FirePos.transform.position;
            ParticleSystem fs = Fire.GetComponent<ParticleSystem>();
            fs.Play();
            Destroy(Fire, 3);
        }
    }

    void TurnDestination()
    {
        Quaternion lookRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotate);
    }

    void MoveDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, Enemyspeed * Time.deltaTime);
    }
   
   


    void CreatBloodEffect()

    {
        
        GameObject blood = Instantiate(bloodFac);
        blood.transform.position = transform.position;
        ParticleSystem ps= blood.GetComponent<ParticleSystem>();
        ps.Play();
        Destroy(blood, 3);

    }
  
}

