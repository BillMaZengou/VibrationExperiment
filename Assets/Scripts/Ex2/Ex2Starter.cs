using UnityEngine;

public class Ex2Starter : MonoBehaviour
{
    public GameObject spawn;
    public GameObject Base;
    public GameObject shell;
    public GameObject button;
    public GameObject LeftHand;
    public GameObject LeftController;

    private Transform startPoint;

    public bool ifStart;
    // Start is called before the first frame update

    private void OnEnable()
    {
        startPoint = spawn.transform;
        button.transform.position = startPoint.position;
        button.transform.rotation = startPoint.rotation;
        ifStart = false;
    }

    public void Restart()
    {
        Base.SetActive(false);
        shell.SetActive(false);
        button.SetActive(false);
        LeftHand.SetActive(false);
        LeftController.SetActive(true);
        ifStart = true;
    }
}