using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sr;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > transform.position.y)
        {
            sr.sortingOrder = 9;
        }
        else
        {
            sr.sortingOrder = 2;
        }
    }
}
