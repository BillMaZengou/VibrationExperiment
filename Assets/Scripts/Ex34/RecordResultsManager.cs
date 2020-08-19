using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class RecordResultsManager : MonoBehaviour
{
    private string filePath;
    public GameObject Manager;
    private ExpManagement functions;
    private GameObject button;
    private GameObject pusher;

    private IfStart Starter;
    private int whichOne;
    private CountTime timer;
    private string timeInterval;
    private bool caseDone = false;
    private bool timeDone = false;
    private bool ifCount = false;

    private List<string> answers;
    StringBuilder builder = new StringBuilder();
    private string tempAns;

    public GameObject gound;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + gameObject.name + ".txt";

        functions = Manager.gameObject.GetComponent<ExpManagement>();
        button = functions.button;
        pusher = functions.pusher;

        answers = new List<string>();
        timer = pusher.GetComponent<CountTime>();
        Starter = button.GetComponent<IfStart>();
    }

    private void OnDisable()
    {
        if (ifCount == true)
        {
            RecordResults();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Starter.ifChosen == true)
        {
            whichOne = functions.whichOne + 1;
            caseDone = true;
            ifCount = true;
        }

        if (timer.ifRecord == true)
        {
            timeInterval = timer.DeltaTime;
            timeDone = true;
        }

        if (caseDone == true && timeDone == true)
        {
            tempAns = whichOne.ToString("d") + ", " + timeInterval;
            answers.Add(tempAns);
            caseDone = false;
            timeDone = false;
        }

        if (OVRInput.Get(OVRInput.Button.Three))
        {
            gameObject.SetActive(false);
        }
    }

    void RecordResults()
    {
        try
        {
            if (gound != null)
            {
                builder.Append("Dropped: ").Append(gound.GetComponent<IfDrop>().numOfDrop).Append("\n");
            }
            foreach (string result in answers)
            {
                builder.Append(result).Append(",").Append("\n");
            }
            string results = builder.ToString();
            File.WriteAllText(filePath, results);

            Debug.Log(results);
            Debug.Log(filePath);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }
}
