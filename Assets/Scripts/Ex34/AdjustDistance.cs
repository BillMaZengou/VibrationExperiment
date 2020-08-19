using System.Collections.Generic;
using UnityEngine;

public class AdjustDistance : MonoBehaviour
{
    public GameObject Manager;
    private ExpManagement functions;
    private GameObject pusher;
    private List<GameObject> Points = new List<GameObject>();

    public string axis;
    public float separateAngle;

    private void Start()
    {
        functions = Manager.gameObject.GetComponent<ExpManagement>();
        Points = functions.checkers;
        pusher = functions.pusher;
        Adjust(Points, pusher);
    }

    private void Adjust(List<GameObject> changingObject, GameObject origin) {
        Vector3 displacement = changingObject[0].transform.position - origin.transform.position;
        float portion = Mathf.Floor(changingObject.Count / 2);
        float dAngle = separateAngle / portion;
        //Debug.Log(dAngle);
        int i = -Mathf.FloorToInt(changingObject.Count / 2);
        foreach (GameObject changingTarget in changingObject) {
            switch (axis) {
                case "x":
                    changingTarget.transform.position = Quaternion.Euler(dAngle * i, 0, 0) * displacement + origin.transform.position;
                    break;
                case "y":
                    changingTarget.transform.position = Quaternion.Euler(0, dAngle * i, 0) * displacement + origin.transform.position;
                    break;
                case "z":
                    changingTarget.transform.position = Quaternion.Euler(0, 0, dAngle * i) * displacement + origin.transform.position;
                    break;
            }
            i++;
        }
    }
}
