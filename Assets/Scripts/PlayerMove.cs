using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    //character controller
    CharacterController cc;

    //jump power
    public float jumpPower = 5;
    //y �ӵ� 
    float yVelocity;
    //�߷�
    float gravity = -20;

    int countJump = 0;
    public int jumpMax = 2;
    
   
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
 
    }

    void Update()
    {
      

        //WASD �̵�
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dirAD = transform.right * h;
        Vector3 dirWS = transform.forward * v;
        Vector3 dir = dirAD + dirWS;
        dir.Normalize();

        Jump(out dir.y);




        cc.Move(dir * speed * Time.deltaTime);

        
    }
    void Jump(out float dirY)
    {

        if (cc.isGrounded)
        {
            yVelocity = 0;
            countJump = 0;
        }
        //jump
        if (Input.GetButtonDown("Jump")) //Input.GetKeyDown(KeyCode.Space)
        {
            if (countJump < jumpMax)
            {
                //y�ӵ��� jump power�� �Ѵ�
                yVelocity = jumpPower;
                countJump++;
            }

        }

        //dir.y�� �ӵ��� �ִ´�
        dirY = yVelocity;
        //y�ӵ��� �߷��� �����ش�
        yVelocity += gravity * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Base")
        {
            Debug.Log("Base");
            Gui.instance.gameObject.SetActive(true);


        }
    }
   
}
