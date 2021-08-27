using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Player�Ʒ� Camera�� �޾������

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private float range;  // ������ ������ ������ �ִ� �Ÿ�

    private bool pickupActivated = false;  // ������ ���� �����ҽ� True 

    private RaycastHit hitInfo;  // �浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask;  //Item ���̾ ����

    [SerializeField]
    private Text actionText;  // ���� ���� �˸� �ؽ�Ʈ

    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CheckItem();
            CanPickUp();
        }
    }

    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
                
            }
        }
        else
            ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        Debug.Log("ȹ�氡��");
        actionText.gameObject.SetActive(true);
        actionText.text = "Press" + "<color=yellow>" + " (I) " + "</color>" + "To Pick Up " + hitInfo.transform.GetComponent<ItemPickUp>().item.itemName;
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        Debug.Log("ȹ��Ұ�");
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�.");  // �κ��丮 �ֱ�
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
