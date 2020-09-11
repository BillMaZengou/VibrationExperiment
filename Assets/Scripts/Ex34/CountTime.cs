using UnityEngine;

public class CountTime : MonoBehaviour
{
    private float initialTime;
    private float currentTime;
    public string DeltaTime;
    public bool ifRecord;
    public IfCollide groundDetection;
    private bool collideWithGround;

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
        collideWithGround = groundDetection.collideGround;
        if (collideWithGround)
        {
            DeltaTime = "Null";
        }
        Debug.Log("Time saved");
        Debug.Log(DeltaTime);
    }

}
