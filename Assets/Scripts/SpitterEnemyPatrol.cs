using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterEnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rdb2;
    private void Start()
    {
        rdb2 = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isFacingRight())
        {
            rdb2.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rdb2.velocity = new Vector2(-speed, 0f);
        }
    }

    private bool isFacingRight()
    {
        return gameObject.transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        
        transform.localScale = new Vector2(-(Mathf.Sign(rdb2.velocity.x)), transform.localScale.y);
       
    }

    

    
    
    /*public Transform groundDetection; 
    
    private bool isMovingRight;
    private float distance = 2f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if(groundinfo.collider == null)
        {
            if(isMovingRight)
            {
                gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                isMovingRight = false;
            }
            else
            {
                gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                isMovingRight = true;
            }
        }
    }*/
}
