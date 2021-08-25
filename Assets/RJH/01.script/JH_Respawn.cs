using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Respawn : MonoBehaviour
{

    List<Transform> spawnPos = new List<Transform>();
    GameObject[] monsters;

    public GameObject monsterFac;
    public int spawnNumber = 1;
    public float resawnDealy = 3f;

    int deadMonsters = 0;
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

        monsters = new GameObject[spawnNumber];

        MakeMonsters();
    }

    //몬스터 관리
    void MakeMonsters()
    {
        for(int i = 0; i<spawnNumber; i++)
        {
            GameObject mon = Instantiate(monsterFac, spawnPos[i].position, Quaternion.identity) as GameObject;
            mon.SetActive(false);

            monsters[i] = mon;
        }
    }

    void SpawnMonster()
    {
        for (int i = 0; i<monsters.Length; i++)
        {
            monsters[i].SetActive(true);
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
