using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;

    public ScoreController scoreController;
    public GameOverController gameOverController;
    private Rigidbody2D rdb2;
    private float horizontal;

    private float vertical;
    private void Start()
    {
        rdb2 = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Jump");
        
        PlayerMovementAnimation(horizontal, vertical);
        CharacterMovement(horizontal, vertical);
        Crouch();
    }

    public void PickUpKey()
    {
        Debug.Log("Player has pickedup key!");
        scoreController.IncrementScore(10);
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
        animator.SetFloat("Speed",Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        
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
        
    private void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", false);
        }
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ChomperEnemy"   || collision.gameObject.tag == "SpitterEnemy")
        {
            SoundManager.Instance.Play(Sounds.Collisionwithenemy);
            HealthController.health--;
            if(HealthController.health <= 0)
            {
                gameOverController.OnPlayerDie();
                this.enabled = false;
            }
        }
    }
    
}
