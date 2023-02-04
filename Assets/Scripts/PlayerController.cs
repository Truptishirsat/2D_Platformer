
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playercontrollers : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;

    private Rigidbody2D rdb2;
    private void Awake()
    {
        rdb2 = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        
        float horizontal = Input.GetAxisRaw ("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovementAnimation(horizontal, vertical);
        CharacterMovement(horizontal, vertical);

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
    }

    private void CharacterMovement(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += speed * horizontal * Time.deltaTime;
        transform.position = position;

        if(vertical > 0)
        {
            rdb2.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }


    }
    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
        Vector3 scale = transform.localScale;
        animator.SetFloat("Speed",Mathf.Abs(horizontal));
         
        if(horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        transform.localScale = scale;
    }
        
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D : " + collision.gameObject.name);
    }

   
    
}
