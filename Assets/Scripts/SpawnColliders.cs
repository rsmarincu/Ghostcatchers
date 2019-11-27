using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class SpawnColliders : MonoBehaviour
{
    [HideInInspector] 
    public List<GameObject> prefabList;

    public Graves prefabs;

    private Tilemap tilemap;
    private int numberOfColliders;

    [HideInInspector]
    public List<Vector3> colliderSpots = new List<Vector3>();

    void Awake()
    {   
        prefabList = prefabs.prefabList;

        numberOfColliders = Random.Range(5,20);

        tilemap = gameObject.GetComponent<Tilemap>();

        tilemap.CompressBounds();

        Vector3 bottomTile = tilemap.cellBounds.position;

        Vector3 tilemapSize = tilemap.cellBounds.size;

        Spawn(numberOfColliders, tilemapSize, bottomTile);
            
    }

    public void Spawn(int numberofColliders, Vector3 size, Vector3 origin){        

        for (int i=0; i<numberOfColliders; i++){

            Vector3 randomSpot = new Vector3();

            randomSpot.x = Random.Range(0, (int) size.x) + 0.5f;
            randomSpot.y = Random.Range(0, (int) size.y) + 0.5f;

            while (colliderSpots.Contains(randomSpot)){

                randomSpot.x = Random.Range(0, size.x);
                randomSpot.y = Random.Range(0, size.y);
            }

            randomSpot.x += origin.x;
            randomSpot.y += origin.y;

            colliderSpots.Add(randomSpot);

            int index = Random.Range(0, prefabList.Count);

            Instantiate(prefabList[index], randomSpot, Quaternion.identity);
        }

    }
}
