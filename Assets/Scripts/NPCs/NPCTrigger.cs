using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCTrigger : MonoBehaviour
{
    public GameObject speechBubble;
    public DialogueManager dm;
    public Rocks rk;
    public Wood wd;
    public Axe ax;
    public GameObject ship2;
    public GameObject ship3;
    public GameObject fire;
    public GameObject UsedGem;
    public AudioSource openBubble;
    public AudioSource closeBubble;
    public AudioSource glass;
    public Hache h;
    public GameObject cutLog;
    public AudioSource log;
    public GameObject hamoc;
    public bool logIsCut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "NPC")
        {
            if (collision.gameObject.tag == "Player")
            {
                speechBubble.SetActive(true);
                openBubble.Play();
                dm.StartNPCDialogue();
            }
        }

        if (gameObject.tag == "Fire")
        {
            speechBubble.SetActive(true);
            openBubble.Play();
            dm.StartFireDialogue();

            if (rk.hasRocks && wd.hasWood)
            {
                speechBubble.SetActive(false);
                fire.SetActive(true);
                ship2.SetActive(true);
                Invoke("DestroyDeadFire", 0.01f);
            }
        }

        if (gameObject.tag == "Gem")
        {
            if (collision.gameObject.tag == "Player")
            {
                speechBubble.SetActive(true);
                openBubble.Play();
                dm.StartGemDialogue();

                if (ax.hasAxe)
                {
                    speechBubble.SetActive(false);
                    ship3.SetActive(true);
                    UsedGem.SetActive(true);
                    glass.Play();
                    Invoke("DestroyUsedGem", 0.01f);
                }
            }
        }

        if (gameObject.tag == "Wood")
        {
            if (collision.gameObject.tag == "Player")
            {
                if (!h.hasHache)
                {
                    speechBubble.SetActive(true);
                    openBubble.Play();
                    dm.StartWoodDialogue();
                }

                if (h.hasHache)
                {
                    speechBubble.SetActive(false);
                    cutLog.SetActive(true);
                    hamoc.SetActive(true);
                    logIsCut = true;
                    log.Play();
                    Invoke("DisableLog", 0.01f);
                }
            }
        }

    }

    private void DisableLog()
    {
        gameObject.SetActive(false);
    }

    private void DestroyDeadFire()
    {
        gameObject.SetActive(false);
    }

    private void DestroyUsedGem()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speechBubble.SetActive(false);
            closeBubble.Play();
            dm.npcDialogueText.text = string.Empty;
            dm.fireDialogueText.text = string.Empty;
            dm.gemDialogueText.text = string.Empty;
        }
    }
}