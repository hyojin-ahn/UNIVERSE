using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JH_FoodItem : MonoBehaviour
{

    public GameObject[] Item; //������ ������
    public Transform playerTransform;// �÷������� Ʈ������
    
    public float maxDistance= 10f; //�ִ�Ÿ�\
    public float maxSpawn = 10f; // ���� �ð� �ִ� ����
    public float minSpawn = 3f;  // �����ð� �ּ� ����
    
    private float timespawn;// ��������
    private float lastSpawnTime; //������

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
            //������ ���� �ð� ����
            lastSpawnTime = Time.deltaTime;
            //���� �ֱ⸦ �������� ����
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
