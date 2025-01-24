using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hache : MonoBehaviour
{
    public bool hasHache = false;
    public AudioSource log;
    public SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasHache= true;
            log.Play();
            sr.sprite = null;
            Invoke("DisableHache", 1);
        }
    }

    private void DisableHache()
    {
        gameObject.SetActive(false);
    }
}
