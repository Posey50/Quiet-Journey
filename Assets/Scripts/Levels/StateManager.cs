using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public List<GameObject> lvls = new List<GameObject>();
    public List<string> states = new List<string>();
    public List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    public List<GameObject> startPos = new List<GameObject>();

    public int i = 0;
    public int iMax;

    public string currentState;
    public GameObject currentLvl;

    PlayerMovement player;
    public Vector3 targetPos;

    void Start()
    {
        iMax = states.Count - 1;
        currentState = states[i];
        currentLvl = lvls[i];

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        targetPos = startPos[i].transform.position;
    }

    public void switchState()
    {
        currentState = states[i];
        switchLvl();
    }
    public void switchLvl()
    {
        // desactive current lvl and set the new current lvl
        currentLvl.SetActive(false);
        currentLvl = lvls[i];

        switch (currentState)
        {
            case "state1":
                lvls[i].SetActive(true);
                targetPos = startPos[i].transform.position;
                CameraSwitcher.SwitchCamera(cameras[i]);
                StartCoroutine(spawnPlayer());
                break;

            case "state2":
                lvls[i].SetActive(true);
                targetPos = startPos[i].transform.position;
                CameraSwitcher.SwitchCamera(cameras[i]);
                StartCoroutine(spawnPlayer());
                break;

            case "state3":
                lvls[i].SetActive(true);
                targetPos = startPos[i].transform.position;
                CameraSwitcher.SwitchCamera(cameras[i]);
                StartCoroutine(spawnPlayer());
                break;

            case "state4":
                lvls[i].SetActive(true);
                targetPos = startPos[i].transform.position;
                CameraSwitcher.SwitchCamera(cameras[i]);
                StartCoroutine(spawnPlayer());
                break;

        }
    }
    private void OnEnable()
    {
        foreach (CinemachineVirtualCamera camera in cameras)
        {
            CameraSwitcher.Register(camera);
        }
        CameraSwitcher.SwitchCamera(cameras[0]);
    }

    public IEnumerator spawnPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        player.transform.position = targetPos;
        yield return null;
    }

    public void SwitchNextLvl()
    {
        //check if the next index is not the last in the list
        if (i + 1 <= iMax)
        {
            //go to the next state
            i++;
            switchState();
        }

        //check if next state is note superior to iMax
        if (i + 1 > iMax)
        {
            return;
        }
    }

    public void SwitchPreviousLvl()
    {
        //check if the next index is not the last in the list
        if (i - 1 >= 0)
        {
            //go to the next state
            i--;
            switchState();
        }

        //check if next state is not lower to iMax
        else if (i + 1 < 0)
        {
            return;
        }
    }

}