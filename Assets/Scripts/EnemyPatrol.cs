using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Transform[] waypoints;
    private float speed = 2f; 
    private int currentindex;

    
    private void Start()
    {
        currentindex = 1;   
    }

    private void Update()
    {
        Transform wp = waypoints[currentindex];
        Vector3 scale = transform.localScale;
        
        if(Vector3.Distance(transform.position, wp.position) < 0.01f)
        {
            currentindex = 1 - currentindex;
            scale.x = -1f * scale.x;
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
        }

        transform.localScale = scale;
    }



}
