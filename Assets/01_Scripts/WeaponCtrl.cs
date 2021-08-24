using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour
{
    /* ���� ���� */
    // �����̸�
    public string weaponName;
    // �� źâ�� źȯ��
    public int bulletsPerMag;
    // �ܿ� źȯ ����
    public int bulletsTotal;
    // ���� ������ źȯ ����
    public int currentBullets;
    // ��Ÿ�
    public float range;
    // �߻� ����
    public float fireRate;

    // �߻� �ӵ�
    private float fireTimer;
    public AudioSource audio;
    public AudioClip shootsound;

    // ����ĳ��Ʈ ��������
    public Transform shootPoint;

    /* �ִϸ��̼� */
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        // �� �Ѿ��� �� = źâ �Ѿ� ����
        currentBullets = bulletsPerMag;

        // �ִϸ��̼�
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton ("Fire1"))
        {
            // ���� �Ѿ��� 0 �̻��̸� �߻�
            if (currentBullets > 0)
                Fire();
        }

        // ���� �߻�ӵ��� �߻簣�ݺ��� ���ٸ�
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    private void Fire()
    {
        // �߻� ���ݺ��� �߻� ������ ������ fire �Լ��� �����Ѵ�
        if (fireTimer < fireRate)
        {
            return;
        }

        Debug.Log("Shot Fired!");

        // ����ĳ��Ʈ (��������, ����, ������ ��ü�� hit�� ����, ����)
        RaycastHit hit;
        // ����ĳ��Ʈ�� �����Ǿ��� ���� ����ǰ� �ʹ�
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log("Hit!");
        }
        currentBullets--;

        // �ʱ�ȭ
        fireTimer = 0.0f;

        // ����� ���
        audio.PlayOneShot(shootsound);
        anim.CrossFadeInFixedTime("Fire", 0.01f);
    }
}
