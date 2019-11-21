using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    public bool good;

    public void TestGhost(Ghost ghost){

        if (ghost != good){
            SceneManager.LoadScene("Death");
        }
        else{
            GhostInventory.instance.RemoveGhost(ghost);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {

                Ghost current = GhostInventory.instance.getCurrentGhost();
                Debug.Log(current.name);
                TestGhost(current);
            }
        }

    }
}
