using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed;
    private Vector2 movement;
    Rigidbody2D rb;
    new SpriteRenderer renderer = null;
    Animator animator = null;
    public AudioClip[] grassFootstepsSFX;
    public AudioClip[] dirtFootstepsSFX;
    public AudioClip[] sandFootstepsSFX;

    public AudioSource audioSource;
    public bool canPlay = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canPlay)
        {
            renderer.flipX = movement.x >= 0.00f;
            animator.SetBool("isBackWalking", movement.x == 0.00f && movement.y == 1.00f);
            animator.SetBool("isFrontWalking", movement.x == 0.00f && movement.y == -1.00f);
            animator.SetBool("isHorizontalWalking", movement.x == -1.00f && movement.y == 0.00f
                             || movement.x == 1.00f && movement.y == 0.00f);
            animator.SetBool("isDiagonalBackWalking", movement.x < 0.0f && movement.y > 0.00f
                             || movement.x > 0.00f && movement.y > 0.00f);
            animator.SetBool("isDiagonalFrontWalking", movement.x < 0.0f && movement.y < 0.00f
                             || movement.x > 0.00f && movement.y < 0.00f);

            rb.MovePosition(rb.position + movement * walkSpeed * Time.deltaTime);
        }
    }

    private void OnMove(InputValue value)
    {
        if (canPlay)
        {
            movement = value.Get<Vector2>();
        }
    }

    private void Step()
    {
        if (transform.position.x < 17)
        {
            AudioClip clip = GetRandomDirtClip();
            audioSource.PlayOneShot(clip);
        }
        if (transform.position.x > 10.5f && transform.position.x < 75)
        {
            AudioClip clip = GetRandomSandClip();
            audioSource.PlayOneShot(clip);
        }
        if (transform.position.x > 75)
        {
            AudioClip clip = GetRandomGrassClip();
            audioSource.PlayOneShot(clip);
        }
    }
    private AudioClip GetRandomGrassClip()
    {
        int index = Random.Range(0, grassFootstepsSFX.Length - 1);
        return grassFootstepsSFX[index];
    }

    private AudioClip GetRandomDirtClip()
    {
        int index = Random.Range(0, dirtFootstepsSFX.Length - 1);
        return dirtFootstepsSFX[index];
    }

    private AudioClip GetRandomSandClip()
    {
        int index = Random.Range(0, sandFootstepsSFX.Length - 1);
        return sandFootstepsSFX[index];
    }

}