using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class recordResults1 : MonoBehaviour
{
    private List<string> answers;
    private ifStart Starter;
    private int whichOne;
    private CountTime timer;
    private string timeInterval;
    private string filePath;
    private bool caseDone = false;
    private bool timeDone = false;
    private bool ifCount = false;
    StringBuilder builder = new StringBuilder();
    private string tempAns;

    public string pusherName;
    public string buttonName;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + gameObject.name + ".txt";
        answers = new List<string>();
        timer = FindInActiveObjectByName(pusherName).GetComponent<CountTime>();
        Starter = GameObject.Find(buttonName).GetComponent<ifStart>();
        //Debug.Log(filePath);
        //Debug.Log(timer);
        //Debug.Log(Starter);
    }

    private void OnDisable()
    {
        if (ifCount == true) {
            RecordResults();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Starter.ifChosen == true) {
            whichOne = Starter.whichOne + 1;
            //Debug.Log(whichOne);
            caseDone = true;
            ifCount = true;
        }

        if (timer.ifRecord == true) {
            timeInterval = timer.DeltaTime;
            //Debug.Log(timeInterval);
            timeDone = true;
        }

        if (caseDone == true && timeDone == true) {
            tempAns = whichOne.ToString("d") + ", " + timeInterval;
            answers.Add(tempAns);
            //Debug.Log(answers);
            caseDone = false;
            timeDone = false;
        }
    }

    void RecordResults()
    {
        try
        {
            foreach (string result in answers)
            {
                builder.Append(result).Append(",").Append("\n");
            }
            string results = builder.ToString();

            //Debug.Log("Opened file!");
            //Debug.Log("About to write into file!");
            File.WriteAllText(filePath, results);
            Debug.Log(filePath);
            Debug.Log(results);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
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