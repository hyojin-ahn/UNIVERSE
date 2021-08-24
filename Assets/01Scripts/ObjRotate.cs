using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    //ȸ����(x,y)
    float mx;
    float my;
    //ȸ�� �ӵ�
    float rotSpeed = 150;
    //ȸ�� ���� ����
    public bool canRotH;
    public bool canRotV;

    void Start()
    {
        //���� ���ӿ�����Ʈ�� ���� ����
        mx = transform.eulerAngles.x;
        my = transform.eulerAngles.y;
    }

    void Update()
    {
        //���콺�� �������� �޾� ���� ���
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        //������ ȸ���� ���� 
        if (canRotV == true) mx += v * rotSpeed * Time.deltaTime;
        if (canRotH == true) my += h * rotSpeed * Time.deltaTime;



        //���� ����
        //if (mx < -60)   mx = -60;
        //if (mx < 60)    mx = 60;
        mx = Mathf.Clamp(mx, -60, 60);


        //���� ������Ʈ ���� ����
        transform.localEulerAngles = new Vector3(-mx, my, 0);

    }
}
