using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2Starter : MonoBehaviour
{
    public GameObject Spawn;
    public GameObject Base;
    public GameObject Shell;
    private Vector3 startPoint;
    public GameObject LeftHand;
    public GameObject LeftController;

    public bool ifStart;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = Spawn.transform.position;
        gameObject.transform.position = startPoint;
        ifStart = false;
        //Debug.Log(Spawn);
        //Debug.Log(Shell);
        //Debug.Log(Base);
    }

    private void OnEnable()
    {
        gameObject.transform.position = startPoint;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.name == Base.name)
        {
            Debug.Log("base");
            // Do stuff
            Base.SetActive(false);
            Shell.SetActive(false);
            gameObject.transform.rotation = Quaternion.identity;
            LeftHand.SetActive(false);
            LeftController.SetActive(true);
            gameObject.SetActive(false);
            ifStart = true;
        }
    }
}