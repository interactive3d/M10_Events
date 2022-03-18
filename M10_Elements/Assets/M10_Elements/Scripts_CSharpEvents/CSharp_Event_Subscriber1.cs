using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp_Event_Subscriber1 : MonoBehaviour
{
    /// <summary>
    /// this is based on     // this is based on https://youtu.be/OuZrhykVytg
    /// </summary>
    private void Start()
    {
        CSharp_Event_Broadcaster testingEvents = GameObject.Find("MySceneManager").GetComponent<CSharp_Event_Broadcaster>();
        testingEvents.OnSpacePressed += TestingEvents_OnSpacePressed;
    }

    private void TestingEvents_OnSpacePressed(object sender, System.EventArgs e)
    {
        Debug.Log("The event triggered from the other object");
        Debug.Log("Second time it will not work");
        // to run that only once we can unsubscribe at this moment
        CSharp_Event_Broadcaster testingEvents = GameObject.Find("MySceneManager").GetComponent<CSharp_Event_Broadcaster>();
        testingEvents.OnSpacePressed -= TestingEvents_OnSpacePressed;

    }
}
