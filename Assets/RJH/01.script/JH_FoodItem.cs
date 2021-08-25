using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JH_FoodItem : MonoBehaviour
{

    public GameObject[] Item; //생성할 아이템
    public Transform playerTransform;// 플레리어의 트랜스폼
    
    public float maxDistance= 10f; //최대거리\
    public float maxSpawn = 10f; // 스폰 시간 최대 간격
    public float minSpawn = 3f;  // 스폰시간 최소 간격
    
    private float timespawn;// 생성간격
    private float lastSpawnTime; //마지막

    public GameObject EffectPos;
    public GameObject itemEffect;

    
    

    // Start is called before the first frame update
    void Start()
    {
        timespawn = Random.RandomRange(minSpawn, maxSpawn);
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime>lastSpawnTime + timespawn && playerTransform !=null)
        {
            //마지막 생성 시간 갱신
            lastSpawnTime = Time.deltaTime;
            //생성 주기를 랜덤으로 변경
            timespawn = Random.Range(minSpawn, maxSpawn);
            spawn();
        }
    }

    void spawn()
    {
        //Vector3 spawnPosition = GetRandomPointOnNavMesh(playerTransform.position, maxDistance);
       //spawnPosition += Vector3.up * 0.7f;
    }

    void GetRandomPointOnNavMesh(Vector3 center, float distance)
    {
        Vector3 randomPos = Random.insideUnitSphere * distance + center;

        NavMeshHit hit;

        //NavMesh.SamplePosition(randomPos.normalized out hit, distance, NavMesh.AllAreas);
        //return hit.position;
    }

    private void OnTriggerEnter(Collider other)
    {
       // Vector3 dir = EffectPos.transform.position;

        if(other.gameObject.CompareTag("Player")==true)
        {
            //Instantiate(itemEffect, dir, Quaternion.identity);
            Destroy(gameObject);

        }
    }

}
