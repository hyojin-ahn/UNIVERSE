using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Item : MonoBehaviour
{
    public enum Type
    {
        EnergyDrink,
        Meat,
        Snack,
        Bar
    }
    public Type item;
   

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FPSController")
        {

            Destroy(gameObject);

        }
    }
}
