using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Counter : MonoBehaviour
{

    #region VARIABLES

    public Text LogTextCounter;
    public int touchCounter;

    #endregion

    #region Unity Functions

    private void Start()
    {
        if (LogTextCounter == null)
        {
            LogTextCounter = GameObject.FindObjectOfType<Text>();
        }

        LogTextCounter.enabled = true;
    }

    void Update()
    {
        touchCounter = Input.touchCount;

        if (touchCounter > 0)
        {
            // there are toches detected
            // LogTextCounter.text = "Touch Count: " + touchCounter.ToString();

            // here we could trigger the event that some touches are detected
        }
        else
        {
            
        }
        LogTextCounter.text = "Touch Count: " + touchCounter.ToString();
    }

    private void OnEnable()
    {
        LogTextCounter.enabled = true;
    }
    private void OnDisable()
    {
        if (LogTextCounter != null)
        {
            LogTextCounter.enabled = false;
        }
        
    }

    #endregion

    #region Helper Functions

    #endregion






}
