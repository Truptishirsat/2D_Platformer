using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrollers : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        
    }
    private void Update()
    {
        
        Vector3 scale = transform.localScale;

        float speed = Input.GetAxisRaw ("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed",Mathf.Abs(speed));
        animator.SetFloat("Jump", jump);


        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }

        if(speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D : " + collision.gameObject.name);
    }

   
    
}
