using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp_E_Delegates : MonoBehaviour
{
    public delegate void MyEventName();
    public event MyEventName EventExisting;

    public delegate void MyEventNameWithVariable(int varMe);
    public event MyEventNameWithVariable EventWithVariable;  

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            EventExisting?.Invoke(); // invoke an event
            EventWithVariable?.Invoke(3); // invoke an event with a variable
        }
    }

}
