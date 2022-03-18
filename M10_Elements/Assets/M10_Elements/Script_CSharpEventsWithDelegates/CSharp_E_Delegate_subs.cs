using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp_E_Delegate_subs : MonoBehaviour
{
    public CSharp_E_Delegates eventPublisher;

    private void OnEnable()
    {
        eventPublisher.EventExisting += myFunctionHere;
        eventPublisher.EventWithVariable += myFunctionWithParameter;
    }


    private void OnDisable()
    {
        eventPublisher.EventExisting -= myFunctionHere;
        eventPublisher.EventWithVariable -= myFunctionWithParameter;
    }

    public void myFunctionHere()
    {
        Debug.Log("An event triggered this function");
    }

    public void myFunctionWithParameter(int param)
    {
        Debug.Log("Event trigger this function with parameter " + param.ToString());
    }
}
