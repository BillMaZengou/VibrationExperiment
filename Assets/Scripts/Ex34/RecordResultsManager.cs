using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

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
    private bool ifSave = false;

    private List<string> answers;
    StringBuilder builder = new StringBuilder();
    private string tempAns;

    public GameObject gound;
    public TextMeshProUGUI simpleUIText;
    public int ifContinueCondition;

    public ContactPlay nameFrom;
    private string vibrate;
    private string symmetric;
    private string ifRandom;
    private string idx;

    // Start is called before the first frame update
    void Start()
    {
        if (nameFrom.vibration)
        {
            vibrate = "Vib";
            if (nameFrom.symmetric)
            {
                symmetric = "Sine";
                vibrate += symmetric;
            }
            else
            {
                if (nameFrom.ifRandomise)
                {
                    ifRandom = "Random";
                    vibrate += ifRandom;
                }
            }
        }
        else
        {
            vibrate = "NoVib";
        }

        filePath = Application.persistentDataPath + vibrate + ".txt";
        Debug.Log(filePath);

        functions = Manager.gameObject.GetComponent<ExpManagement>();
        button = functions.button;
        pusher = functions.pusher;

        answers = new List<string>();
        timer = pusher.GetComponent<CountTime>();
        Starter = button.GetComponent<IfStart>();
        ifContinueCondition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ifContinueCondition = answers.Count;
        if (ifContinueCondition < 15)
        {
            if (Starter.ifChosen == true)
            {
                whichOne = functions.whichOne + 1;
                ifCount = true;
                caseDone = true;
            }

            if (timer.ifRecord == true)
            {
                timeInterval = timer.DeltaTime;
                timeDone = true;
            }

            if (caseDone == true && timeDone == true)
            {
                idx = ifContinueCondition.ToString();
                tempAns = idx + ", " + whichOne.ToString("d") + ", " + timeInterval;
                Debug.Log(tempAns);
                answers.Add(tempAns);
                caseDone = false;
                timeDone = false;
                timer.ifRecord = false;
            }
        }
        else
        {
            if (ifSave)
            {
                Saved();
            }
            else
            {
                Store();
                if (OVRInput.Get(OVRInput.Button.Three))
                {
                    if (ifCount == true)
                    {
                        RecordResults();
                        ifCount = false;
                    }
                }
            }
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
                builder.Append(result).Append(",\n");
            }
            string results = builder.ToString();
            File.WriteAllText(filePath, results);
            ifSave = true;
            Debug.Log(results);
            Debug.Log(filePath);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    void Store()
    {
        simpleUIText.text = "Please Store your answers";
    }

    void Saved()
    {
        simpleUIText.text = "Answers Have Been Saved";
    }
}
