using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;
    public GameObject particlesystem;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            collision.gameObject.SetActive(false);
            gameManager.gameOn = false;
            particlesystem.SetActive(true);
            Debug.Log("Level Completed");
        }
    }
}
