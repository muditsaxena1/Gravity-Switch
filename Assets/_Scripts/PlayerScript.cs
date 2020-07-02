using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    GameManager gameManager;
    public GameObject particlesystem;
    TrailRenderer tr;
    Camera cam;
    Rigidbody rb;
    float buffer = 1f;
    int waitFrames;

    float leftBound, rightBound, topBound, bottomBound;

    //new stuff
    //public int nextSceneLoad;
    //public  bool isCompleted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<TrailRenderer>();
        cam = Camera.main;
        gameManager = GameManager.instance;
        Vector3 temp = cam.ScreenToWorldPoint(new Vector3(-buffer, -buffer, 0f));
        leftBound = temp.x;
        bottomBound = temp.y;
        temp = cam.ScreenToWorldPoint(new Vector3(Screen.width + buffer, Screen.height + buffer, 0f));
        rightBound = temp.x;
        topBound = temp.y;

        //new stuff
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void FixedUpdate()
    {
        if(waitFrames > 0)
        {
            waitFrames--;
            if (waitFrames == 0)
            {
                tr.time = 0.5f;
            }
        }
        if (transform.position.x > rightBound)
        {
            tr.time = 0f;
            Vector3 pos = transform.position;
            pos.x = leftBound;
            transform.position = pos;
            waitFrames = 2;
        }
        if (transform.position.x < leftBound)
        {
            tr.time = 0f;
            Vector3 pos = transform.position;
            pos.x = rightBound;
            transform.position = pos;
            waitFrames = 2;
        }
        if (transform.position.y < bottomBound)
        {
            tr.time = 0f;
            Vector3 pos = transform.position;
            pos.y = topBound;
            transform.position = pos;
            waitFrames = 2;
        }
        if (transform.position.y > topBound)
        {
            tr.time = 0f;
            Vector3 pos = transform.position;
            pos.y = bottomBound;
            transform.position = pos;
            waitFrames = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            collision.gameObject.SetActive(false);
            gameManager.gameOn = false;
            particlesystem.SetActive(true);
            //new stuff
            //isCompleted = true;
            

            Debug.Log("Level Completed");
        }
    }
}
