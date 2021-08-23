using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    //회전값(x,y)
    float mx;
    float my;
    //회전 속도
    float rotSpeed = 150;
    //회전 가능 여부
    public bool canRotH;
    public bool canRotV;

    void Start()
    {
        //현재 게임오브젝트의 각도 세팅
        mx = transform.eulerAngles.x;
        my = transform.eulerAngles.y;
    }

    void Update()
    {
        //마우스의 움직임을 받아 각도 계산
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        //구해진 회전값 저장 
        if (canRotV == true) mx += v * rotSpeed * Time.deltaTime;
        if (canRotH == true) my += h * rotSpeed * Time.deltaTime;



        //범위 설정
        //if (mx < -60)   mx = -60;
        //if (mx < 60)    mx = 60;
        mx = Mathf.Clamp(mx, -60, 60);


        //게임 오브젝트 각도 세팅
        transform.localEulerAngles = new Vector3(-mx, my, 0);

    }
}
