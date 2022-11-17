using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public int slotID;//空格ID 等于 物品ID
    public Item slotItem;
    public Image slotImage;
    public TextMeshProUGUI slotNum;
    public string slotInfo;

    public GameObject itemInSlot;
    public void ItemOnClicked()
    {
        InventoryManage.UpdateItemInfo(slotInfo);
    }
    public void SetUpSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInformation;
    }
}