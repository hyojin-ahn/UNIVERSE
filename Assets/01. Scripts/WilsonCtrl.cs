using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCtrl : MonoBehaviour
{
	/* 움직임 */
	Vector3 rot = Vector3.zero;

	/* 스피드 */
	[Range(5.0f, 50.0f)]
	public float moveSpeed = 20f;
	[Range(5.0f, 50.0f)]
	public float rotSpeed = 20f;

	/* 애니메이션 */
	Animator anim;

	/* 목표물 = 주인공 */
	public GameObject Player;
	public Transform pet;
	public Transform PlayerPos;
	bool PlayerMove;

	/* 공격 Effect */
	public GameObject attckEf;
	bool IsAttack;

	/* 슬롯 UI */
	public GameObject slot;

	// Use this for initialization
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 dir = Player.transform.position - this.transform.position;
		//pet.position = Vector3.Lerp(dir.normalized * 5 * Time.deltaTime);
		//pet.rotation = Quaternion.Lerp(Vector3.forward * moveSpeed * Time.deltaTime);

		RoboMove();
		gameObject.transform.eulerAngles = rot;
	}

	void RoboMove()
	{
		/* 걷기 */
		/* 플레이어와 일정거리 유지하면서 따라오고 플레이어가 돌면 같이 돈다 */
		if (PlayerMove == true)
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (PlayerMove == false)
		{
			anim.SetBool("Walk_Anim", false);
		}
		/* 만약 플레이어 포스라면 */
		

		/* 공격 */
		/* Q 누르면 몸 굴려서 적 공격, 다시 되돌아온다 */  //Enemy -> Pet 태그와 부딪히면 튕겨나가 hp 깎인다
		/* Q 누르고 있는 동안은 공격 */
		/* 떼면 원상태로 돌아와서 추적모드 */
		if (Input.GetKey(KeyCode.Q))
		{
			IsAttack = true;
			EnemyAttack();
		}
	}

	/* 애너미 공격하기 */
	void EnemyAttack()
    {
		if (IsAttack == true)
        {
			anim.SetBool("Roll_Anim", true);
		}
    }

	/* 슬롯 */
	/* 슬롯 창 세개 제공 */
	public void Slot()
    {
		/* 만약 F2키를 누르면 */
		if (Input.GetKeyDown(KeyCode.F2))
        {
			/* 슬롯 UI가 등장한다 */
			slot.SetActive(true);

			if (Input.GetKeyDown(KeyCode.F2))
			{
				/* 슬롯 창이 닫힌다 */
				slot.SetActive(false);
            }
        }
    }

}
