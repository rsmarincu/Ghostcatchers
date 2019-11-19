using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OrderInLayerTilemap : MonoBehaviour
{
    private GameObject player;
    private TilemapRenderer tr;

    void Start()
    {
        tr = gameObject.GetComponent<TilemapRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            tr.sortingOrder = 9;
        }
        else
        {
            tr.sortingOrder = 2;
        }
    }
}
