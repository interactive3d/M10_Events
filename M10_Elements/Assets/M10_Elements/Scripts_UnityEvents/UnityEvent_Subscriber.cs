using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent_Subscriber : MonoBehaviour
{
    // Start is called before the first frame update
    public void ThisIsTriggered()
    {
        Debug.Log("This was triggered with Unity Event");
    }

    public void ThisIsTriggeredAndAcceptParameter(int param)
    {
        Debug.Log("This also was triggered and also store integer " + param);
    }
}
