using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hamoc : MonoBehaviour
{
    public GameObject EndScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EndScreen.SetActive(true);
            Invoke("ReturnToStart", 5);
        }
    }

    private void ReturnToStart()
    {
        SceneManager.LoadScene("FinalLevel");
        EndScreen.SetActive(false);
    }
}
