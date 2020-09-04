using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    protected int ItemNumber = 0;
    public virtual void  SummonItem()
    {
        Debug.Log("This item doesn't have a summon programmed in it.");
    }

    public void SetItemStart(int itemNumber, int itemUses)
    {
        ItemNumber = itemNumber;
        GetComponentInChildren<Text>().text = itemUses.ToString();
    }

    public virtual void UnsumonItem()
    {
        Debug.Log("This item doesn't have a unsummon programmed in it.");
    }

}
