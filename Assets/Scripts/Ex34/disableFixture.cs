using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableFixture : MonoBehaviour
{
    public string fixtureName;
    public string contactName;

    private GameObject fixture;
    //private GameObject contact;

    private void Start()
    {
        fixture = GameObject.Find(fixtureName);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == contactName) {
            fixture.SetActive(false);
        }
    }
}
