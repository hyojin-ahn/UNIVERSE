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
    //y 속도 
    float yVelocity;
    //중력
    float gravity = -20;

    int countJump = 0;
    public int jumpMax = 2;
    
   
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
 
    }

    void Update()
    {
      

        //WASD 이동
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
                //y속도를 jump power로 한다
                yVelocity = jumpPower;
                countJump++;
            }

        }

        //dir.y에 속도를 넣는다
        dirY = yVelocity;
        //y속도에 중력을 더해준다
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
