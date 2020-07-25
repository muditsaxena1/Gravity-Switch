using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public float force = 30f;
    public GameObject explode;
    Rigidbody2D rb;
    bool forceActivated = false;
    Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!forceActivated && (collision.gameObject.tag == "Player" || collision.gameObject.tag == "MovingPlatform"))
        {
            rb.AddForce(transform.up * force * 3);
            forceActivated = true;
        }
    }

    private void FixedUpdate()
    {
        if (forceActivated)
        {
            rb.AddForce(transform.up * force * Time.deltaTime);

            Vector3 posInScreen = cam.WorldToScreenPoint(transform.position);

            if(posInScreen.x > Screen.width || posInScreen.y < 0 || posInScreen.y > Screen.height || posInScreen.y < 0)
            {
                Instantiate(explode, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
