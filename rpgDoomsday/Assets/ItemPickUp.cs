using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Sword;
    //public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void pickUp()
    {
        Debug.Log("Picking up" + Sword.itemName);
        //bool wasPickedUp = inventory.AddItem(Sword);
        //Destroy(gameObject);
    }
}
