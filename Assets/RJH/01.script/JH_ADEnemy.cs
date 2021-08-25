using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    


    public GameObject player;
    
    public NavMeshAgent agent;

    
    public int EnemycurrHp ;
    public int EnemyMaxHP;

    public GameObject bloodFac;
    

    public Animator animator;
    
    
    float currentTime;
    public float idleDelayTime = 0.5f;
    public BoxCollider Attackbox;
    
    void Start()
    {

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
        if (DistancePlayer() < chaseDistance)
        {
            currentState = State.Chase;
            animator.SetBool("Run", true);

        }

       
     
    }
    void ChaseState()
    {
            TurnDestination();
            MoveDestination();
        if (DistancePlayer() < attackDistance)
        {
            currentState = State.Attack;
        }

    }
    void AttackState()
    {
            animator.SetBool("Run", false);

        float targetRadius = 1.5f;
        float targetRange = 2;
        RaycastHit[] RayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
            if(RayHits.Length>0 && !isAttack)
            {
                StartCoroutine(Attack());
            }
            
        if (DistancePlayer() > reChaseDistance)
        {
            
            currentState = State.Idle;
           
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
            EnemycurrHp -= 20;
            animator.SetTrigger("Hit");

            print(EnemycurrHp);
            if (EnemycurrHp <= 0)
            {
                isDead = true;
                agent.isStopped = true;
                animator.SetTrigger("Death");
                Destroy(gameObject,3f);

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
        Quaternion lookRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotate);
    }

    void MoveDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Enemyspeed * Time.deltaTime);
    }
   
    float DistancePlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance;
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

