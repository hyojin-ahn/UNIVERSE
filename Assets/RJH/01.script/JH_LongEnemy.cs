using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_LongEnemy : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Damage,
        Die
    }


    public enum Type 
    {
       Long,
       Short,
       Boss
    }

    CharacterController cc;
    public EnemyState m_state = EnemyState.Idle;
    public Type monster ;
    public GameObject target;

    public Animator animator;
    public float currentTime; // 현재시간
    public float rotate = 5; // 회전 속도
    public GameObject FireballFac; // 총알 공장
    public GameObject firepos;//총알 나가는곳
    public int currentHp;//현재 HP
    public int MaxHp;//최대 hp
    public GameObject turret;

    public 


    // Start is called before the first frame update
    void Start()
    {
        cc= GetComponent<CharacterController>();
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        print("현재상태:" + m_state);
        switch (m_state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damage:
                Damage();
                break;
            case EnemyState.Die:
                Die();
                break;


        }
    }

    public float targetRange = 10;
    void Idle()
    {
        if(Distance()<targetRange)
        {

            m_state = EnemyState.Idle;
           
        }
        else
        {
            animator.SetBool("ss", true);
            m_state = EnemyState.Move;
        }
    }
    public float attackRange;
    void Move()
    {
        if (Distance() < attackRange)
        {
            m_state = EnemyState.Attack;
            
        }

        else
        {
            TurnDestination();
           
        }
    }

    void Attack()
    {
        currentTime += Time.deltaTime;
        if (Distance() < targetRange)
        {
            animator.SetBool("Attack", true);

            //RaycastHit [] rayHits =  Physics.SphereCastAll(transform.position, )
            //switch(monster)
            //{
            //    case Type.Long:
            //    GameObject fireball=Instantiate(FireballFac);
            //    fireball.transform.forward = firepos.transform.forward;
            //    fireball.transform.position = firepos.transform.position;
            //    break;

            //    case Type.Short:
            //        yield return new WaitForSeconds(0.2f);
                     
            //        break;

            //}
            
        }
    }
    public float damageDelayTime = 2;
    void Damage()
    {
        currentTime += Time.deltaTime;
        if (currentTime > damageDelayTime)
        {
            m_state = EnemyState.Idle;
            currentTime = 0;
        }
    }

    void Die()
    { 
    
    }


    void TurnDestination()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * rotate);
    }

    float Distance()
    {

        float distance = Vector3.Distance(transform.position, target.transform.position);
        return distance;
    }

    public void OnDamageProcess(Vector3 shootDirection)
    {
        currentHp -= 20;

        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }

        else
        {
            m_state = EnemyState.Damage;
        }
    }
}
