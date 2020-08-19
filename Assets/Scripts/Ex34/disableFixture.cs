using UnityEngine;

public class DisableFixture : MonoBehaviour
{
    public GameObject Manager;
    private ExpManagement functions;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<ExpManagement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == functions.contact.name)
        {
            functions.fixture.SetActive(false);
        }
    }
}