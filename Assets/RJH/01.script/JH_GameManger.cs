using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_GameManger : MonoBehaviour
{

    public static JH_GameManger instance;

    List<GameObject> Monster = new List<GameObject>();

    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
    }

    //�ܺ� ����Ʈ�� �����ϰ��ִ�
    public void AddNewMonster(GameObject mon)
    {

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
