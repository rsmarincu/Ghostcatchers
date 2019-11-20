using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public Ghost ghost;
    private GameObject parent;
    private EnemyWanderRandom enemyWanderRandom;

    private void Start()
    {
        parent = gameObject.transform.parent.gameObject;
        enemyWanderRandom = parent.GetComponent<EnemyWanderRandom>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("Killed " + ghost.ghostName);
                bool wasKilled = GhostInventory.instance.AddGhost(ghost);
                if (wasKilled)
                {
                    Destroy(parent);
                    Destroy(enemyWanderRandom.fv.gameObject);
                }
            }
        }
    }

    public void setGhost(Ghost ghost){
        this.ghost = ghost;
    }

}
