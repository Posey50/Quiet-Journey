using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject mainMenu;
    public Animator animator = null;
    PlayerMovement player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void Launch()
    {
        animator.SetBool("isFading", true);
        StartCoroutine(Desactive());
    }

    IEnumerator Desactive()
    {
        yield return new WaitForSeconds(1.999f);
        player.canPlay = true;
        mainMenu.SetActive(false);
    }

    private void OnEnable()
    {
        animator.SetBool("credits", false);
    }
}