using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    public Ghost ghost;
    void Awake(){

        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Ghost Inventory");
            return;
        }

        instance = this;
    }

    public void setGhost(Ghost newGhost){

        this.ghost = newGhost;
    }

}
