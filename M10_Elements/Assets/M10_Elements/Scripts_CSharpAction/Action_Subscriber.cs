
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Subscriber : MonoBehaviour
{
    public Action_Publisher myActionPublisher;

    private void OnEnable()
    {
        myActionPublisher.OnActionEvent1 += ActionTriggeredFunction;
        myActionPublisher.OnActionEvent2 += ActionTriggeredFunctionWithParam;

    }
    private void OnDisable()
    {
        myActionPublisher.OnActionEvent1 -= ActionTriggeredFunction;
        myActionPublisher.OnActionEvent2 -= ActionTriggeredFunctionWithParam;
    }

    public void ActionTriggeredFunction()
    {
        Debug.Log("This is action triggered report");
    }

    public void ActionTriggeredFunctionWithParam(bool bT, int numA)
    {
        Debug.Log("This is action triggered report with parameters " + bT + " and " + numA);
    }
}
