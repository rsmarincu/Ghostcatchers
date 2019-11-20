using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    private Ghost ghost;

    public int index;

    public List<GameObject> spots;

    void Awake(){
        
    }
    void Start()
    {

        ghost = GhostObjectManager.instance.getGhost(index);

        ghost.Load();
        
        ghostPrefab.GetComponent<EnemyWanderRandom>().setSpots(spots);

        ghostPrefab.GetComponentInChildren<CollectEnemy>().setGhost(ghost);

        Instantiate(ghostPrefab, this.transform.position, Quaternion.identity);

    }


}
