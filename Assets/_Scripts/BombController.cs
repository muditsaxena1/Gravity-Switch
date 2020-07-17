using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float force = 10f;
    public Rigidbody2D playerRb;
    public GameObject explode;
    public AudioClip explodeAudioClip;
    public AudioSource interactableAudioSource;
    public float bombExplodeVolume;
    public CameraShake cameraShake;
    public float cameraShakeDuration;
    public float cameraShakeMagnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(explode, transform.position, Quaternion.identity);
            interactableAudioSource.clip = explodeAudioClip;
            interactableAudioSource.volume = bombExplodeVolume;
            interactableAudioSource.Play();
            StartCoroutine(cameraShake.Shake(cameraShakeDuration, cameraShakeMagnitude));
            Vector2 direction = playerRb.position - new Vector2(transform.position.x,transform.position.y);
            playerRb.AddForce(force * direction.normalized);
            Destroy(gameObject);
        }
    }
}
