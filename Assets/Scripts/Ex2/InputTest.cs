using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;

public class InputTest : MonoBehaviour
{
    private bool running;
    private bool executing;
    private List<string> answers;
    private float initialTime;
    private float currentTime;
    private string filePath;
    StringBuilder builder = new StringBuilder();
    public TextMeshProUGUI simpleUIText;
    private string currentSceneName;
    public bool ifPlay;

    private bool posOrNot;
    private int whichWave;
    private RandomPlayer JudgeFrom;
    private Ex2Starter StartFrom;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        executing = true;
        filePath = Application.persistentDataPath + currentSceneName + "Result.txt";
        answers = new List<string>();
        ifPlay = false;
        running = false;
        JudgeFrom = gameObject.GetComponent<RandomPlayer>();
        StartFrom = GameObject.Find("StartButton").gameObject.GetComponent<Ex2Starter>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(executing)
        running = StartFrom.ifStart;
        //Debug.Log(running);
        if (running)
        {
            //Debug.Log(running);
            currentTime = Time.time;
            if (currentTime - initialTime > 1.0f)
            {
                Test();
                posOrNot = JudgeFrom.PosOrNeg;
                whichWave = JudgeFrom.whichOne;
            }

            if (currentTime - initialTime > 5.0f)
            {
                executing = true;
                //Debug.Log("Please provide the answer OR store your answers");
                Provide();
            }

            if (executing)
            {
                if (OVRInput.Get(OVRInput.Button.Three))
                {
                    RecordResults();
                    //Debug.Log(filePath);
                    running = false;
                    StartFrom.Base.SetActive(true);
                    StartFrom.Shell.SetActive(true);
                    StartFrom.LeftController.SetActive(false);
                    StartFrom.LeftHand.SetActive(true);
                    StartFrom.gameObject.SetActive(true);
                }

                JudgeIfUp();
            }
        }
        else {
            initialTime = Time.time;
        }
    }

    void JudgeIfUp() {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            //Debug.Log("Left");
            Up();
            answers.Add(WriteTpye() + "Up\n");
            executing = false;
            initialTime = currentTime;
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            //Debug.Log("Right");
            Down();
            answers.Add(WriteTpye() + "Down\n");
            executing = false;
            initialTime = currentTime;
        }
    }

    void RecordResults()
    {
        try
        {
            executing = false;
            initialTime = currentTime;

            foreach (string result in answers) {
                builder.Append(result).Append(",");
            }
            string results = builder.ToString();

            //Debug.Log("Opened file!");
            //Debug.Log("About to write into file!");
            File.WriteAllText(filePath, results);
            Debug.Log(filePath);
            Debug.Log(results);
            Saved();
    }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    void Test()
    {
        ifPlay = true;
        simpleUIText.text = "Testing...";
    }

    void Provide() {
        ifPlay = false;
        simpleUIText.text = "Your answer OR Store";
    }

    void Up()
    {
        simpleUIText.text = "Up";
    }

    void Down()
    {
        simpleUIText.text = "Down";
    }

    void Saved()
    {
        simpleUIText.text = "Answers Have Been Saved";
    }

    string WriteTpye() {
        if (posOrNot)
        {
            return "Posive" + JudgeFrom.PosSoundTypes[whichWave].name;
        }
        else {
            return "Negative" + JudgeFrom.NegSoundTypes[whichWave].name;
        }
    }
}
