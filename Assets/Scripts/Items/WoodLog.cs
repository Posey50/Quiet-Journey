using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLog : MonoBehaviour
{
    public bool logIsCut = false;
    public GameObject hamoc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            logIsCut= true;
            hamoc.SetActive(true);
            Invoke("DisableLog", 0.01f);
        }
    }

    private void DisableLog()
    {
        gameObject.SetActive(false);
    }
}
