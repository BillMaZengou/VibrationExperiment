using System.Collections;
using System.Collections.Generic;
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

    public List<GameObject> checkerNames;

    public void Restart()
    {
        button.SetActive(false);
        Base.SetActive(false);
        shell.SetActive(false);
        button.transform.position = buttonSpawn.transform.position;

        pusher.SetActive(true);
        fixture.SetActive(true);
        contact.SetActive(true);
    }

    public void EndRound()
    {
        button.SetActive(true);
        Base.SetActive(true);
        shell.SetActive(true);

        pusher.SetActive(false);
        fixture.SetActive(false);
        contact.SetActive(false);
        pusher.transform.position = pusherSpawn.transform.position;
    }
}
