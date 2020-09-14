using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class ItemCubo : Item
{
    GameObject ItemPrefab;
    GameObject ItemToPut;
    bool isActivated;

    Main GameController;
    Text TextUses; 

    private void Start()
    {
        ItemPrefab = Resources.Load("Prefabs/SummonedCubo") as GameObject;
        GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>();
        TextUses = GetComponentInChildren<Text>();
    }
    public override void SummonItem()
    {
        if (isActivated)
        {
            if(ItemToPut.GetComponent<SpriteRenderer>().color == Color.green)
            {
                isActivated = false;
                ItemToPut.GetComponent<BoxCollider2D>().isTrigger = false;
                Rigidbody2D rgb = ItemToPut.GetComponent<Rigidbody2D>();
                rgb.bodyType = RigidbodyType2D.Dynamic;
                rgb.mass = 4f;
                rgb.drag = 4f;
                rgb.gravityScale = 4f;
                ItemToPut.tag = "Platform";
                ItemToPut = null;
                GameController.ChangeItemUse(ItemNumber, 1);
                TextUses.text = (int.Parse(TextUses.text) - 1).ToString();
            }
        }
        else
        {
            ItemToPut = Instantiate(ItemPrefab);
            ItemToPut.GetComponent<SpriteRenderer>().color = Color.green;

            isActivated = true;
        }
    }

    public override void UnsumonItem()
    {
        isActivated = false;
        Destroy(ItemToPut);
        GameController.ChangeItemUse(ItemNumber, 0);
    }

    void Update()
    {
        if (isActivated)
        {
            ItemToPut.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
    }

}
