using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public bool hasRocks = false;
    public AudioSource rocks;
    public SpriteRenderer sr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasRocks = true;
            rocks.Play();
            sr.sprite = null;
            Invoke("DisableRocks", 1);
        }
    }

    private void DisableRocks()
    {
        gameObject.SetActive(false);
    }
}
