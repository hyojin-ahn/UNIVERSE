using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_FoodRespawn : MonoBehaviour
{

    List<Transform> spawnPos = new List<Transform>();
    GameObject[] food;

    public GameObject foodFac;
    public int spawnNumber = 1;
    public float resawnDealy = 3f;

    
    void Start()
    {
        MakeSpawnPos();
    }

    void MakeSpawnPos()
    {
        foreach (Transform pos in transform)
        {
            if (pos.tag == "Respawn")
            {
                spawnPos.Add(pos);
            }
        }
        if(spawnNumber>spawnPos.Count)
        {
            spawnNumber = spawnPos.Count;
        }

        food = new GameObject[spawnNumber];

        MakeMonsters();
    }

    //몬스터 관리
    void MakeMonsters()
    {
        for(int i = 0; i<spawnNumber; i++)
        {
            GameObject sci = Instantiate(foodFac, spawnPos[i].position, Quaternion.identity) as GameObject;
            sci.SetActive(false);

            food[i] = sci;
        }
    }

    void SpawnMonster()
    {
        for (int i = 0; i<food.Length; i++)
        {
            food[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            SpawnMonster();
            GetComponent<SphereCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
