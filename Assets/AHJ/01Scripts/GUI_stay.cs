using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_stay : MonoBehaviour
{
	public static GUI_stay instance;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	// Start is called before the first frame update
	void Start()
    {
		GameObject inventory = transform.Find("Inventory").gameObject;
		inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
