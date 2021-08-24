using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour
{
    /* 무기 스펙 */
    // 무기이름
    public string weaponName;
    // 한 탄창의 탄환수
    public int bulletsPerMag;
    // 잔여 탄환 개수
    public int bulletsTotal;
    // 현재 장전된 탄환 개수
    public int currentBullets;
    // 사거리
    public float range;
    // 발사 간격
    public float fireRate;

    // 발사 속도
    private float fireTimer;
    public AudioSource audio;
    public AudioClip shootsound;

    // 레이캐스트 시작지점
    public Transform shootPoint;

    /* 애니메이션 */
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        // 현 총알의 수 = 탄창 총알 개수
        currentBullets = bulletsPerMag;

        // 애니메이션
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton ("Fire1"))
        {
            // 만약 총알이 0 이상이면 발사
            if (currentBullets > 0)
                Fire();
        }

        // 만약 발사속도가 발사간격보다 적다면
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    private void Fire()
    {
        // 발사 간격보다 발사 시점이 적으면 fire 함수를 종료한다
        if (fireTimer < fireRate)
        {
            return;
        }

        Debug.Log("Shot Fired!");

        // 레이캐스트 (시작지범, 방향, 감지된 객체를 hit에 저장, 길이)
        RaycastHit hit;
        // 래이캐스트에 감지되었을 때만 실행되고 싶다
        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log("Hit!");
        }
        currentBullets--;

        // 초기화
        fireTimer = 0.0f;

        // 오디오 재생
        audio.PlayOneShot(shootsound);
        anim.CrossFadeInFixedTime("Fire", 0.01f);
    }
}
