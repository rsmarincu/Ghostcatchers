﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostInventory : MonoBehaviour
{

    public static GhostInventory instance;

    public List<Ghost> ghostList = new List<Ghost>();

    private int inventorySpace = 5;

    public delegate void OnEvent();

    public OnEvent OnEventCallback;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Ghost Inventory");
            return;
        }

        instance = this;
    }

    public bool AddGhost(Ghost ghost)
    {
        if (ghostList.Count >= inventorySpace)
        {
            return false;
        }
        
        ghostList.Add(ghost);

        if(OnEventCallback != null)
        {
            OnEventCallback.Invoke();
        }
        

        return true;
    }
    
    public void RemoveGhost(Ghost ghost)
    {
        ghostList.Remove(ghost);

        if (OnEventCallback != null)
        {
            OnEventCallback.Invoke();
        }
    }


}
