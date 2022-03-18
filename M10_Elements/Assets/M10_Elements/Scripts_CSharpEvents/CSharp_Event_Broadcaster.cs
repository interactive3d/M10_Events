using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp_Event_Broadcaster : MonoBehaviour
{
    // this script will be responsible for publishing some events
    // it is assigned to some object like i.e. MySceneManager gameObject
    /// <summary>
    /// this is based on     // this is based on https://youtu.be/OuZrhykVytg
    /// </summary>

    public event EventHandler OnSpacePressed;

    private void Start()
    {
        // OnSpacePressed += Testing_OnSpacepressed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            /*
            // E pressed
            if(OnSpacePressed != null)
            {
                OnSpacePressed(this, EventArgs.Empty);
            }
            */
            OnSpacePressed?.Invoke(this, EventArgs.Empty);

        }
    }
/*    private void Testing_OnSpacepressed(object sender, EventArgs e)
    {
        Debug.Log("Space");
    }*/


}
