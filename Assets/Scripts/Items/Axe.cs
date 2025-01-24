using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public bool hasAxe = false;
    public AudioSource axe;
    public SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasAxe = true;
            axe.Play();
            sr.sprite = null;
            Invoke("DisableAxe", 1);
        }
    }

    private void DisableAxe()
    {
        gameObject.SetActive(false);
    }
}
