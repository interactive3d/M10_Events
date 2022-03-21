// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Position : MonoBehaviour
{

    #region VARIABLES

    public bool singleFinger, multiFinger, muliFingerID;

    public Text logTouchPosition;
    private int touchCounter;

    [Range(0, 9)]
    public int trackedTouchNo;

    public GameObject touchPosIndicator;

    // for dynamic assignment multiple position indicators
    public GameObject myRootIndicator;
    public List<GameObject> touchPosIndicators = new List<GameObject>();

    #endregion


    #region UnityFunctions

    private void OnEnable()
    {
        logTouchPosition.enabled = true;
    }
    private void OnDisable()
    {
        if (logTouchPosition != null)
        {
            logTouchPosition.enabled = false;
        }

    }

    private void Start()
    {
        if (logTouchPosition == null)
        {
            Debug.Log("No label selected - I will do it automatically to random text");
            logTouchPosition = GameObject.FindObjectOfType<Text>();
        }

        if (touchPosIndicator == null)
        {
            // here error message
            Debug.Log("No position indicator allocated");
            // possible creation of the one
        }

        // GetAllIndicators();
        CreateAllIndicators();

    }

    private void Update()
    {
        touchCounter = Input.touchCount;


        // in this section the single finger indicator with the name ID is being moved
        // its position will be display in the UI by using the ShowTouchPosition
        if (singleFinger && touchCounter > 0 && touchCounter > trackedTouchNo)
        {
            touchPosIndicator.transform.position = Input.GetTouch(trackedTouchNo).position;
            ShowTouchPosition((Vector2)Input.GetTouch(trackedTouchNo).position, trackedTouchNo);
        }

        // in this section each touch will be assigned to be represent in the moving indicator
        if (multiFinger && touchCounter > 0 && touchCounter <= touchPosIndicators.Count)
        {
            if (touchPosIndicators.Count > 0)
            {
                for (int i = 0; i < touchCounter; i++)
                {
                    touchPosIndicators[i].transform.position = Input.GetTouch(i).position;
                }
            }
        }


        // in this section the indicators become static, so even if the finger get lifted the indicator stays
        // we will use Finger ID

        if (muliFingerID && touchCounter > 0 && touchCounter <= touchPosIndicators.Count)
        {
            if (touchPosIndicators.Count > 0)
            {
                for (int i = 0; i < touchCounter; i++)
                {
                    // we need to extract the part of the name of the object that will state its ID
                    // in the name of the FingerIndicator after underscore sign _ there is a number
                    string[] FingerIDName = touchPosIndicators[i].name.Split('_');
                    // int FingerIDNameInt = Int32.Parse(FingerIDName[1]);
                    int FingerIDNameInt;
                    int.TryParse(FingerIDName[1], out FingerIDNameInt);
                    // Debug.Log(FingerIDNameInt + 100);
                    touchPosIndicators[Input.GetTouch(i).fingerId].transform.position = Input.GetTouch(i).position;
                }
            }
        }

    }

    #endregion


    #region Helper Functions

    public void ShowTouchPosition(Vector2 touchPos, int touchNo)
    {
        logTouchPosition.text = "Touch " + touchNo + " Position: " + touchPos;
    }

    public void GetAllIndicators()
    {
        // check if the root indicator is selected
        if (myRootIndicator != null)
        {
            int children = myRootIndicator.transform.childCount;
            for (int i = 0; i < children; i++)
            {
                touchPosIndicators.Add(myRootIndicator.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            Debug.Log("No root indicator selected");
        }
    }


    public void CreateAllIndicators()
    {
        int howMany = 5;
        GameObject referenceIndicator = touchPosIndicator;
        // create a new list
        List<GameObject> newIndicators = new List<GameObject>();

        // add the amound howMany template objects as GameObject
        for (int i=0; i<howMany; i++)
        {
            GameObject newElement = Instantiate(referenceIndicator);
            newElement.name = "FingerIndicatorN_" + i;
            newElement.transform.SetParent(myRootIndicator.transform);
            // newElement.transform.parent = myRootIndicator.transform;

            // for each element in the list get the text change
            newElement.transform.GetComponentInChildren<Text>().text = (i+1).ToString(); // give Text field a value
            newElement.transform.GetComponent<Image>().color = RandomColor(); // set the random color
            newElement.transform.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f); // make sure each has a scale correct
            newElement.AddComponent<FingerIDTracker>(); // Add specific script Component to the elements
            newElement.GetComponent<FingerIDTracker>().fingerID = i+1; // sets the value in each component
            newIndicators.Add(newElement);
        }
        GetAllIndicators();

        
        
        // for each element in the list assign a color

        // for each element on the list 
    }

    public Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Color myColor = new Color(r,g,b);
        return myColor;
    }
    #endregion

}
