using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI npcDialogueText;
    public TextMeshProUGUI fireDialogueText;
    public TextMeshProUGUI gemDialogueText;
    public TextMeshProUGUI woodDialogueText;
    public Berries bs;
    public Rocks rk;
    public Wood wd;
    public Axe ax;
    public Hache h;
    private PlayerInputActions controls;

    [TextArea]
    public string[] npcDialogueSentences;
    [TextArea]
    public string[] fireDialogueSentences;
    [TextArea]
    public string[] gemDialogueSentences;
    [TextArea]
    public string[] woodDialogueSentences;


    public int npcIndex = 0;
    public int fireIndex = 0;
    public int gemIndex = 0;
    public int woodIndex = 0;

    public float typingSpeed = 0.05f;

    public GameObject npcBubble;
    public GameObject fireBubble;
    public GameObject gemBubble;
    public GameObject woodBubble;

    public GameObject enterButton;
    public GameObject aButton;
    public GameObject xbutton;

    public GameObject firstShip;
    public GameObject secondShip;
    public GameObject thirdShip;
    public GameObject end;

    public AudioSource enterSFX;

    public bool canSkip = false;

    private void Awake()
    {
        controls = new PlayerInputActions();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        ContinueNPCDialogue();
    }


    public void StartNPCDialogue()
    {
        StartCoroutine(TypeNPCDialogue());
    }
    public void StartFireDialogue()
    {
        StartCoroutine(TypeFireDialogue());
    }

    public void StartGemDialogue()
    {
        StartCoroutine(TypeGemDialogue());
    }

    public void StartWoodDialogue()
    {
        StartCoroutine(TypeWoodDialogue());
    }



    private IEnumerator TypeNPCDialogue()
    {
        foreach (char letter in npcDialogueSentences[npcIndex].ToCharArray())
        {
            npcDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        if (!bs.hasBerries && npcIndex != 1 || bs.hasBerries && npcIndex != 3)
        {
            canSkip = true;
            enterButton.SetActive(true);
        }
    }
    private IEnumerator TypeFireDialogue()
    {
        if (!rk.hasRocks && !wd.hasWood)
        {
            foreach (char letter in fireDialogueSentences[0].ToCharArray())
            {
                fireDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        if (!rk.hasRocks && wd.hasWood)
        {
            foreach (char letter in fireDialogueSentences[1].ToCharArray())
            {
                fireDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        if (rk.hasRocks && !wd.hasWood)
        {
            foreach (char letter in fireDialogueSentences[2].ToCharArray())
            {
                fireDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        canSkip = true;
        enterButton.SetActive(true);
    }

    private IEnumerator TypeGemDialogue()
    {
        if (!ax.hasAxe)
        {
            foreach (char letter in gemDialogueSentences[0].ToCharArray())
            {
                gemDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        canSkip = true;
        enterButton.SetActive(true);
    }

    private IEnumerator TypeWoodDialogue()
    {
        if (!h.hasHache)
        {
            foreach (char letter in woodDialogueSentences[0].ToCharArray())
            {
                woodDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
    }



    public void ContinueNPCDialogue()
    {
        if (bs.hasBerries && npcIndex != npcDialogueSentences.Length - 1 || !bs.hasBerries && npcIndex != 1)
        {
            if (controls.Player.Confirm.triggered && canSkip)
            {
                enterSFX.Play();
                enterButton.SetActive(false);
                canSkip = false;
                if (npcIndex < npcDialogueSentences.Length)
                {
                    npcIndex++;
                    npcDialogueText.text = string.Empty;
                    StartCoroutine(TypeNPCDialogue());
                }
            }
        }

        if (bs.hasBerries && npcIndex == npcDialogueSentences.Length -1)
        {
            firstShip.SetActive(true);
        }
    }
}
