using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
