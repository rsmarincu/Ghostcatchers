using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class SpawnDestinations : MonoBehaviour
{
    private Tilemap tilemap;
    private int numberOfDestinations;
    
    [HideInInspector]
    public List<Vector3> destinationSpots = new List<Vector3>();

    public List<Vector3> colliderSpots = new List<Vector3>();

    public GameObject spot;

    void Start()
    {   
        colliderSpots = gameObject.GetComponent<SpawnColliders>().colliderSpots;

        numberOfDestinations = Random.Range(5,10);

        tilemap = gameObject.GetComponent<Tilemap>();

        tilemap.CompressBounds();

        Vector3 bottomTile = tilemap.cellBounds.position;

        Vector3 tilemapSize = tilemap.cellBounds.size;

        Spawn(numberOfDestinations, tilemapSize, bottomTile);
            
    }

    public void Spawn(int numberOfDestinations, Vector3 size, Vector3 origin){        

        for (int i=0; i<numberOfDestinations; i++){

            Vector3 randomSpot = new Vector3();

            randomSpot.x = Random.Range(0, (int) size.x) + 0.5f;
            randomSpot.y = Random.Range(0, (int) size.y) + 0.5f;

            while (destinationSpots.Contains(randomSpot) & colliderSpots.Contains(randomSpot)){

                randomSpot.x = Random.Range(0, size.x);
                randomSpot.y = Random.Range(0, size.y);
            }
            
            randomSpot.x += origin.x;
            randomSpot.y += origin.y;

            destinationSpots.Add(randomSpot);

            Instantiate(spot, randomSpot, Quaternion.identity);
        }

    }
}
