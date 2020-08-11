using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDistance : MonoBehaviour
{
    private List<string> PointsName = new List<string>();
    private string pusherName;
    private List<GameObject> Points = new List<GameObject>();
    private GameObject pusher;

    public string buttonName;
    private GameObject button;

    public string axis;
    public float separateAngle;

    private void Start()
    {
        button = GameObject.Find(buttonName);
        PointsName = button.GetComponent<ifStart>().checkerNames;
        pusherName = button.GetComponent<ifStart>().target;
        foreach (string pointName in PointsName) {
            GameObject point = FindInActiveObjectByName(pointName);
            Points.Add(point);
        }
        //Debug.Log(PointsName.Count);
        pusher = FindInActiveObjectByName(pusherName);
        Adjust(Points, pusher);
    }

    private void Adjust(List<GameObject> changingObject, GameObject origin) {
        Vector3 displacement = changingObject[0].transform.position - origin.transform.position;
        float portion = Mathf.Floor(changingObject.Count / 2);
        float dAngle = separateAngle / portion;
        Debug.Log(dAngle);
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

        //For Debug
        //foreach (GameObject changedObject in changingObject)
        //{
        //    Debug.Log((changedObject.transform.position - origin.transform.position).magnitude);
        //    Debug.Log(Vector3.Angle(
        //                            changedObject.transform.position - origin.transform.position,
        //                            changingObject[0].transform.position - origin.transform.position
        //                                                                                            ));
        //}
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
