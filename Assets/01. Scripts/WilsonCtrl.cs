using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WilsonCtrl : MonoBehaviour
{
	/* ������ */
	Vector3 rot = Vector3.zero;

	/* ���ǵ� */
	[Range(5.0f, 50.0f)]
	public float moveSpeed = 20f;
	[Range(5.0f, 50.0f)]
	public float rotSpeed = 20f;

	/* �ִϸ��̼� */
	Animator anim;

	/* ��ǥ�� = ���ΰ� */
	public GameObject Player;
	public Transform pet;
	public Transform PlayerPos;
	bool PlayerMove;

	/* ���� Effect */
	public GameObject attckEf;
	bool IsAttack;

	/* ���� UI */
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
		/* �ȱ� */
		/* �÷��̾�� �����Ÿ� �����ϸ鼭 ������� �÷��̾ ���� ���� ���� */
		if (PlayerMove == true)
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (PlayerMove == false)
		{
			anim.SetBool("Walk_Anim", false);
		}
		/* ���� �÷��̾� ������� */
		

		/* ���� */
		/* Q ������ �� ������ �� ����, �ٽ� �ǵ��ƿ´� */  //Enemy -> Pet �±׿� �ε����� ƨ�ܳ��� hp ���δ�
		/* Q ������ �ִ� ������ ���� */
		/* ���� �����·� ���ƿͼ� ������� */
		if (Input.GetKey(KeyCode.Q))
		{
			IsAttack = true;
			EnemyAttack();
		}
	}

	/* �ֳʹ� �����ϱ� */
	void EnemyAttack()
    {
		if (IsAttack == true)
        {
			anim.SetBool("Roll_Anim", true);
		}
    }

	/* ���� */
	/* ���� â ���� ���� */
	public void Slot()
    {
		/* ���� F2Ű�� ������ */
		if (Input.GetKeyDown(KeyCode.F2))
        {
			/* ���� UI�� �����Ѵ� */
			slot.SetActive(true);

			if (Input.GetKeyDown(KeyCode.F2))
			{
				/* ���� â�� ������ */
				slot.SetActive(false);
            }
        }
    }

}
