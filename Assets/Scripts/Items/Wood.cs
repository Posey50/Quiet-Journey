using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public bool hasWood = false;
    public AudioSource wood;
    public SpriteRenderer sr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasWood = true;
            wood.Play();
            sr.sprite= null;
            Invoke("DisableWood", 1);
        }
    }

    private void DisableWood()
    {
        gameObject.SetActive(false);
    }
}
