﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    InventorySlot[] slots;

    GhostInventory inventory;

    public Transform parent;
    void Start()
    {
        inventory = GhostInventory.instance;
        inventory.OnEventCallback += UpdateUI;

        slots = parent.GetComponentsInChildren<InventorySlot>();

        DontDestroyOnLoad(this.gameObject);
    }

    
    void Update()
    {
      for (int i = 0; i<slots.Length; i++)
        {
            if (i < inventory.ghostList.Count)
            {
                slots[i].AddGhost(inventory.ghostList[i]);
            }
            else
            {
                slots[i].RemoveGhost();
            }
        }
    }

    void UpdateUI()
    {
        Debug.Log("UPDATING UI ");
    }
}