using UnityEngine;

public class IfCollide : MonoBehaviour
{
    public GameObject Manager;
    private ExpManagement functions;

    public GameObject ground;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<ExpManagement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            functions.EndRound();
        }

        if (ground != null)
        {
            if (collision.gameObject.name == ground.gameObject.name)
            {
                functions.EndRound();
            }
        }
    }
}
