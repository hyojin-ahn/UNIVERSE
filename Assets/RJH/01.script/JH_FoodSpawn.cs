using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_FoodSpawn : MonoBehaviour
{

    List<Transform> spawnPos = new List<Transform>();
    GameObject[] foods;

    public GameObject FoodFac;
    public int SpawnNumber = 5;
    
    void Start()
    {
        foreach(Transform pos in transform)
        {
            if(pos.tag == "Respawn")
            {
                spawnPos.Add(pos);
            }
        }
        if(SpawnNumber>spawnPos.Count)
        {
            SpawnNumber = spawnPos.Count;
        }


        foods = new GameObject[SpawnNumber];
        MakeFoods();
    }

    void MakeFoods()
    {
        for (int i = 0; i<SpawnNumber; i++)
        {
            GameObject fod = Instantiate(FoodFac, spawnPos[i].position, Quaternion.identity) as GameObject;
            fod.SetActive(false);

            foods[i] = fod;
        }
    }

    void SpawnFoods()
    {
        for (int i = 0; i < foods.Length; i++)
        {
            foods[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpawnFoods();
            GetComponent<SphereCollider>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
