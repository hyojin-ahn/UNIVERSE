using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

// ���� ������Ʈ�� ���� �ʿ� X 
public class Item : ScriptableObject  
{
    public enum ItemType  // ������ ����
    {
        Repair_Item,
        Food,
        ETC,
    }

    public string itemName; // �������� �̸�
    public ItemType itemType; // ������ ����
    public Sprite itemImage; // �������� �̹���(�κ� �丮 �ȿ��� ���)
    public GameObject itemPrefab;  // �������� ������ (������ ������ ���������� ��)

    //public string weaponType;  // ���� ����
}
