using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfCollide : MonoBehaviour
{
    //private GameObject pusher;
    //private GameObject starter;
    //private GameObject contact;
    //private GameObject Spawn;
    //private GameObject Base;
    //private GameObject BaseShell;
    //private Vector3 initialPosition;
    public GameObject Manager;
    private ExpManagement functions;

    public string buttonName;
    public string spawnPosition;
    public string BaseName;
    public string BaseShellName;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<ExpManagement>();
        //starter = FindInActiveObjectByName(buttonName);
        //Base = FindInActiveObjectByName(BaseName);
        //contact = GameObject.Find("ContactPlane");
        //Spawn = GameObject.Find(spawnPosition);
        //if (BaseShellName != null) {
        //    BaseShell = FindInActiveObjectByName(BaseShellName);
        //}
        //initialPosition = Spawn.transform.position;
        //gameObject.transform.position = initialPosition;
    }

    //private void OnEnable()
    //{
    //    gameObject.transform.position = initialPosition;
    //}

    //private void OnDisable()
    //{
    //    gameObject.transform.position = initialPosition;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            functions.EndRound();
            //collision.gameObject.SetActive(false);
            //contact.SetActive(false);
            //starter.SetActive(true);
            //Base.SetActive(true);

            //if (BaseShell)
            //{
            //    Debug.Log(BaseShellName);
            //    BaseShell.SetActive(true);
            //}

            //gameObject.SetActive(false);
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
