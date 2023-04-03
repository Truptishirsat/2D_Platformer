using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    public GameObject gameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //SoundManager.Instance.Play(Sounds.);
            gameOver.SetActive(true);
        }
    }
}
