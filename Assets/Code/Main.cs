using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main gm;

    public RectTransform ItemSlots;
    int LastItemPick = 0;

    public Item[] ItemPrefab = new Item[4];
    Item[] Item = new Item[4];
    public int[] ItemUses = new int[4];

    //public Transform CharacterPosition;
    //public Vector3 InitialSpawn;
    //public static Vector3 SpawnPosition;

    void Start()
    {
        //Save Master Script
        if(gm == null)
        {
            gm = this;
        }
        //load character position
        ////if (SpawnPosition.x == 0f && SpawnPosition.y == 0f)
        ////    SpawnPosition = InitialSpawn;
        ////CharacterPosition.position = SpawnPosition;
        //Load Items
        for (int i = 0; i < 4; i++)
        {
            if (ItemPrefab[i] == null)
                continue;
            Item[i] = Instantiate(ItemPrefab[i]);
            Item[i].transform.SetParent(ItemSlots.transform);
            Item[i].SetItemStart(i+1, ItemUses[i]);
        }    
    }

    private void Update()
    {
        SummoningItems();
        RestartLevel();
        ItemUnsummon();
    }

    void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        //SpawnPosition = new Vector3(0f, 0f, 0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void ItemUnsummon()
    {
        if (Input.GetMouseButtonDown(1) && LastItemPick != 0)
        {
            Item[LastItemPick-1].UnsumonItem();
        }
    }

    void SummoningItems()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ItemUses[0] > 0 && (LastItemPick == 0 || LastItemPick == 1))
        {
            LastItemPick = 1;
            Item[0].SummonItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && ItemUses[1] > 0 && (LastItemPick == 0 || LastItemPick == 2))
        {
            LastItemPick = 2;
            Item[1].SummonItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && ItemUses[2] > 0 && (LastItemPick == 0 || LastItemPick == 3))
        {
            LastItemPick = 3;
            Item[2].SummonItem();
        }
         
        if (Input.GetKeyDown(KeyCode.Alpha4) && ItemUses[3] > 0 && (LastItemPick == 0 || LastItemPick == 4))
        {
            LastItemPick = 4;
            Item[3].SummonItem();
        }

        if (Input.GetMouseButtonDown(0) && LastItemPick != 0 && ItemUses[LastItemPick - 1] > 0)
        {
            Item[LastItemPick-1].SummonItem();
        }
    }

    //Nota: Cambiar nombre de el método, es exclusivo SOLO para el uso de un item.
    public void ChangeItemUse(int itemNumber, int substraction) {
        ItemUses[itemNumber-1] -= substraction;
        LastItemPick = 0;
    }

    public void SetSpawnPosition(Vector3 newPosition)
    {
        //SpawnPosition = newPosition;
    }

    public void AddItemUse(int itemNumber, int itemQuantity)
    {
        ItemUses[itemNumber - 1] += itemQuantity;
        Item[itemNumber - 1].SetItemStart(itemNumber, ItemUses[itemNumber - 1]);
    }
}
