﻿using System.Collections.Generic;
using UnityEngine;

public class ExpManagement : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonSpawn;
    public GameObject Base;
    public GameObject shell;
    public GameObject pusher;
    public GameObject pusherSpawn;
    public GameObject fixture;
    public GameObject contact;

    public int whichOne = 1000;
    public List<GameObject> checkers;

    public RecordResultsManager recorder;
    private int ifContinueCondition;

    public void Restart()
    {
        button.transform.position = buttonSpawn.transform.position;
        button.transform.rotation = buttonSpawn.transform.rotation;
        button.SetActive(false);
        Base.SetActive(false);
        if (shell != null)
        {
            shell.SetActive(false);
        }

        pusher.transform.position = pusherSpawn.transform.position;
        pusher.SetActive(true);
        contact.SetActive(true);
        if (fixture != null)
        {
            fixture.SetActive(true);
        }

        whichOne = (int)Random.Range(-0.4f, checkers.Count - 0.6f);
        checkers[whichOne].SetActive(true);
    }

    public void EndRound()
    {
        button.transform.position = buttonSpawn.transform.position;
        button.transform.rotation = buttonSpawn.transform.rotation;

        ifContinueCondition = recorder.ifContinueCondition;
        if (ifContinueCondition < 15)
        {
            button.SetActive(true);
            Base.SetActive(true);
            if (shell != null)
            {
                shell.SetActive(true);
            }
        }

        pusher.transform.position = pusherSpawn.transform.position;
        pusher.SetActive(false);
        contact.SetActive(false);
        if (fixture != null)
        {
            fixture.SetActive(false);
        }

        checkers[whichOne].SetActive(false);
        whichOne = 1000;
    }
}