using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject); 
        }
    }

    private void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        {
            //playerInventory.itemList.Add(thisItem);
            // InventoryManage.CreateNewItem(thisItem);
            for (int i = 0; i < playerInventory.itemList.Count; i++)
            {
                if (playerInventory.itemList[i] ==null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break;
                }
            }
        }else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManage.RefreshItem();
    }
    
}
