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

    //외부 리스트와 보관하고있는
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
