using UnityEngine;

public class IfCollide : MonoBehaviour
{
    public GameObject Manager;
    private ExpManagement functions;

    public GameObject ground;
    private bool ifContact;
    public bool collideGround;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<ExpManagement>();
        ifContact = false;
        collideGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target") && ifContact)
        {
            functions.EndRound();
        }

        if (ground != null)
        {
            if (collision.gameObject.name == ground.gameObject.name)
            {
                collideGround = true;
                functions.EndRound();
                collideGround = false;
            }
        }

        if (collision.gameObject.CompareTag("contact"))
        {
            ifContact = true;
            //Debug.Log(ifContact);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ifContact = false;
    }
}
