using UnityEngine;

public class startEx2 : MonoBehaviour
{
    public GameObject Manager;
    private Ex2Starter functions;

    public bool ifChosen = false;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<Ex2Starter>();
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
