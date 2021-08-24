using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    GameObject player;
    public int itemDis=2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float dis= Vector3.Distance(player.transform.position, transform.position);
        if (dis < itemDis)
        {
            //자신을 부수고 아이템 내보내기
        }
    }
}
