using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public Animator animator = null;

    public void LaunchCredits()
    {
        animator.SetBool("credits", true);
    }

}
