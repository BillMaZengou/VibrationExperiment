using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrequencyController : MonoBehaviour
{
    public TextMeshProUGUI output;

    // Start is called before the first frame update
    public void HandelInputData(int val)
    {
        if (val == 0)
        {
            output.text = "Now is 30 Hz";
        }
        else if (val == 1)
        {
            output.text = "Now is 40 Hz";
        }
        else if (val == 2)
        {
            output.text = "Now is 50 Hz";
        }
    }

}
