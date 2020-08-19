using UnityEngine;

public class IfStart : MonoBehaviour
{
    public GameObject Manager;
    private ExpManagement functions;

    public bool ifChosen = false;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<ExpManagement>();
    }

    private void OnEnable()
    {
        ifChosen = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == functions.Base.name)
        {
            functions.Restart();
            ifChosen = true;
        }
    }
}

