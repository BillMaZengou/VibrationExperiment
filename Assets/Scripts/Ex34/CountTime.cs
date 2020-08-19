using UnityEngine;

public class CountTime : MonoBehaviour
{
    private float initialTime;
    private float currentTime;
    public string DeltaTime;
    public bool ifRecord;

    private void OnEnable()
    {
        initialTime = Time.time;
        ifRecord = false;
    }

    private void OnDisable()
    { 
        currentTime = Time.time;
        DeltaTime = (currentTime - initialTime).ToString("f3");
        DeltaTime += " sec";
        ifRecord = true;
    }

}
