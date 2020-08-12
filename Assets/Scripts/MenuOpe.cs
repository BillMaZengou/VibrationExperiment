using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpe : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnResumeClick()
    {
    }

    public void OnEx2Click()
    {
        Debug.Log("Scene2 loading: " + "Ex2");
        SceneManager.LoadScene("Ex2", LoadSceneMode.Single);
    }

    public void OnEx3Click() {
        Debug.Log("Scene2 loading: " + "Ex3");
        SceneManager.LoadScene("Ex34", LoadSceneMode.Single);
    }
}
