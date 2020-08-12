using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifStart : MonoBehaviour
{
    private GameObject contact;
    public int whichOne;

    private GameObject pusher;
    private GameObject Spawn;
    private GameObject Base;
    private GameObject Shell;
    private GameObject fixture;
    private Vector3 startPoint;
    public bool ifChosen = false;

    public string spawnPosition;
    public string target;
    public string baseName;
    public string fixtureName;
    public string shellName;

    public List<string> checkerNames;
    private GameObject checker;

    private void Start()
    {
        Spawn = GameObject.Find(spawnPosition);
        startPoint = Spawn.transform.position;

        Base = GameObject.Find(baseName);
        contact = FindInActiveObjectByName("ContactPlane");

        if (fixtureName != null) {
            fixture = FindInActiveObjectByName(fixtureName);
            //Debug.Log(fixture);
        }

        if (shellName != null)
        {
            Shell = GameObject.Find(shellName);
            //Debug.Log(Shell);
        }

        pusher = FindInActiveObjectByName(target);
        //Debug.Log(pusher);
        gameObject.transform.position = startPoint;
    }

    private void OnEnable()
    {
        gameObject.transform.position = startPoint;
        ifChosen = false;
    }

    private void OnDisable()
    {
        gameObject.transform.position = startPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == baseName)
        {
            // Do stuff
            contact.SetActive(true);
            pusher.SetActive(true);
            Base.SetActive(false);

            if (fixture != null) {
                //Debug.Log("Done");
                fixture.SetActive(true);
            }

            if (Shell != null)
            {
                Shell.SetActive(false);
            }
           
            whichOne = (int)Random.Range(0.0f, checkerNames.Count-0.6f);
            //Debug.Log(whichOne);
            ifChosen = true;
            checker = FindInActiveObjectByName(checkerNames[whichOne]);
            //Debug.Log(checker);
            checker.SetActive(true);

            //gameObject.transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}

