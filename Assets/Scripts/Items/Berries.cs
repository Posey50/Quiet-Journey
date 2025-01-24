using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour
{
    public bool hasBerries = false;
    public DialogueManager dm;
    public ParticleSystem berriesDrop;
    public SpriteRenderer sr;
    public AudioSource branches;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hasBerries = true;
            berriesDrop.Play();
            branches.Play();
            dm.npcIndex = 2;
            sr.sprite = null;
            Invoke("DisableBerries", 1);
        }
    }

    private void DisableBerries()
    {
        gameObject.SetActive(false);
    }
}
