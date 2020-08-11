using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;

public class InputTest : MonoBehaviour
{
    private List<string> answers;
    private bool executing;
    private float initialTime;
    private float currentTime;
    private string filePath;
    StringBuilder builder = new StringBuilder();
    public TextMeshProUGUI simpleUIText;
    private string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        initialTime = Time.time;
        executing = true;
        filePath = Application.persistentDataPath + currentSceneName + "Result.txt";
        answers = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(executing)
        currentTime = Time.time;

        if (currentTime - initialTime > 1.0f) {
            Test();
        }

        if (currentTime - initialTime > 5.0f)
        {
            executing = true;
            Debug.Log("Please provide the answer OR store your answers");
            Provide();
        }

        if (executing)
        {
            if (OVRInput.Get(OVRInput.Button.Three))
            {
                RecordResults();
                Debug.Log(filePath);
            }

            JudgeIfLeft();
            //Test();
        }
    }

    void JudgeIfLeft() {
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))
        {
            Debug.Log("Left");
            Left();
            answers.Add("Left");
            executing = false;
            initialTime = currentTime;
        }
        else if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
        {
            Debug.Log("Right");
            Right();
            answers.Add("Right");
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

            Debug.Log("Opened file!");
            Debug.Log("About to write into file!");
            File.WriteAllText(filePath, results);
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
        simpleUIText.text = "Testing...";
    }

    void Provide() {
        simpleUIText.text = "Your answer OR Store";
    }

    void Left()
    {
        simpleUIText.text = "Left";
    }

    void Right()
    {
        simpleUIText.text = "Right";
    }

    void Saved()
    {
        simpleUIText.text = "Answers Have Been Saved";
    }
}
