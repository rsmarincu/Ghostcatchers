﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWanderRandom : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public List<Vector3> fixedSpots;
    private int randomSpot;
    private float waitTime = 3f;
    private float currentWaitTime ;
    private Vector2 aim;
    private Vector3 destination;
    private Animator animator;
    private Rigidbody2D body;
    private Vector3 scaleDirection;
    private Vector2 oldAim;
    public FiledOfView fv;
    private GameObject fov;

    public bool visible;

    public bool change;
     
    public int currentIndex = 0;

    public bool waiting;


    void Start()
    {
        fov = new GameObject("FOV");

        fov.AddComponent<FiledOfView>();

        
        fov.AddComponent<MeshRenderer>();
        MeshRenderer fovMeshRenderer = fov.GetComponent<MeshRenderer>();
        fov.AddComponent<MeshFilter>();

        Material fovMaterial = Resources.Load("Vision", typeof(Material)) as Material;
        fovMeshRenderer.material = fovMaterial;
        fv = fov.GetComponent<FiledOfView>();
        fv.parent = gameObject;

        fv.ghost = GetComponentInChildren<CollectEnemy>().ghost;
        
        animator = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody2D>();
        randomSpot = Random.Range(0, fixedSpots.Count);
        currentWaitTime = waitTime;
        aim = Vector3.zero;  
    }

    private void Update()
    {
        animator.SetFloat("Speed", aim.sqrMagnitude);

        visible = gameObject.GetComponent<Renderer>().isVisible;

        fv.ghost.visible = visible;

        fv.ghost.index = currentIndex;

 
        if (visible){

            DialogueManager.instance.setGhost(fv.ghost);

        }

    }

    private void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);


        if (aim.x < 0)
        {
            scaleDirection = new Vector3(-1, 1, 1);
        }
        else
        {
            scaleDirection = new Vector3(1, 1, 1);
        }

        transform.localScale = scaleDirection;

        oldAim = aim;

        if (Vector3.Distance(transform.position, destination) < 0.05f)
        {
            waiting = true;
            fv.ghost.waiting = waiting;
            if (currentWaitTime <= 0)
            {
                randomSpot = Random.Range(0, fixedSpots.Count);
                currentWaitTime = waitTime;
                change = true;
            }
            else
            {
                
                if (change){
                    currentIndex += 1;
                    change = false;
                }
                currentWaitTime -= Time.deltaTime;
            }
        }
        else{
            waiting = false;
            fv.ghost.waiting = waiting;
        }
        
        

        destination.x = fixedSpots[randomSpot].x;
        destination.y = fixedSpots[randomSpot].y;

        aim = destination - transform.position;

        fv.setAim(aim);
    }

    public void setSpots(List<Vector3> spots){
        this.fixedSpots = spots;
    }
}
