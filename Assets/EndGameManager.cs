using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    private GhostInventory ghostInventory;
    void Start()
    {
        ghostInventory = GhostInventory.instance;
    }

    void LateUpdate()
    {
        if(ghostInventory.ghostList.Count == 0 & ghostInventory.getHadGhosts()  )
        {
            GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
            if(ghosts.Length == 0)
            {
                SceneManager.LoadScene("EndGame");
            }
        }
    }
}
