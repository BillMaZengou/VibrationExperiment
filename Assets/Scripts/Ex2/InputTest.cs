using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;

public class InputTest : MonoBehaviour
{
    private string filePath;
    private string currentSceneName;
    private bool running;
    private bool executing;
    private List<string> answers;
    StringBuilder builder = new StringBuilder();

    private float initialTime;
    private float currentTime;
   
    public TextMeshProUGUI simpleUIText;
    public bool ifPlay;

    private bool ifSine;
    private bool posOrNot;
    private int whichWave;

    private RandomPlayer JudgeFrom;
    private Ex2Starter StartFrom;

    private int ifContinueCondition;
    private bool ifCount;

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
        StartFrom = GameObject.Find("Exp2Manager").gameObject.GetComponent<Ex2Starter>();
        ifContinueCondition = 0;
        ifCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        ifContinueCondition = answers.Count;
        running = StartFrom.ifStart;
        if (ifContinueCondition < 15)
        {
            if (running)
            {
                currentTime = Time.time;
                if (currentTime - initialTime > 1.0f)
                {
                    Test();
                    ifSine = JudgeFrom.ifSine;
                    posOrNot = JudgeFrom.PosOrNeg;
                    whichWave = JudgeFrom.whichOne;
                }

                if (currentTime - initialTime > 8.0f)
                {
                    executing = true;
                    Provide();
                }

                if (executing)
                {
                    JudgeIfUp();
                }
            }
            else
            {
                initialTime = Time.time;
            }
        }
        else
        {
            if (ifCount) {
                Store();
                if (OVRInput.Get(OVRInput.Button.Three))
                {
                    RecordResults();
                    running = false;
                    StartFrom.button.transform.position = StartFrom.spawn.transform.position;
                    StartFrom.button.transform.rotation = StartFrom.spawn.transform.rotation;
                    StartFrom.Base.SetActive(true);
                    StartFrom.shell.SetActive(true);
                    StartFrom.button.SetActive(true);
                    StartFrom.LeftHand.SetActive(true);
                    StartFrom.LeftController.SetActive(false);
                    ifContinueCondition = 0;
                    ifCount = false;
                }
            }
        }
    }

    void JudgeIfUp() {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            Up();
            answers.Add(WriteTpye() + " Up");
            executing = false;
            initialTime = currentTime;
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            Down();
            answers.Add(WriteTpye() + " Down");
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
                builder.Append(result).Append(",\n");
            }
            string results = builder.ToString();
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
        simpleUIText.text = "Your answer";
    }

    void Up()
    {
        simpleUIText.text = "Up";
    }

    void Down()
    {
        simpleUIText.text = "Down";
    }

    void Store()
    {
        simpleUIText.text = "Please Store your answers";
    }

    void Saved()
    {
        simpleUIText.text = "Answers Have Been Saved";
    }

    string WriteTpye() {
        if (ifSine)
        {
            return "Sine";
        }
        else
        {
            if (posOrNot)
            {
                return "Posive" + JudgeFrom.PosSoundTypes[whichWave].name;
            }
            else
            {
                return "Negative" + JudgeFrom.NegSoundTypes[whichWave].name;
            }
        }
    }
}
