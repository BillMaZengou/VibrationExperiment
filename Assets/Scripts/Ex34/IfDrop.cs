using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfDrop : MonoBehaviour
{
    public int numOfDrop;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        numOfDrop = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ball.name)
        {
            numOfDrop++;
        }
    }
}
