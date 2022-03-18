using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Controller : MonoBehaviour
{
    
    #region Variables

    public Text welcomeText;
    public GameObject ButtonPanel;
    public Button HomeButton;
    public static UI_Controller Instance { get; private set; }

    #endregion

    #region Unity Execution Functions
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
     // StartCoroutine("CheckTheCurrentScene");
    }
    #endregion

    #region Helper Functions
    public void ChangeTheScene(int indexScene)
    {  
        SceneManager.LoadScene(indexScene);
    }

    public void InScene()
    {
        // Debug.Log("Show home button");
        welcomeText.enabled = false;
        ButtonPanel.SetActive(false);
        HomeButton.enabled = true;
    }

    public void InHome()
    {
        // Debug.Log("Show all buttons");
        welcomeText.text = "VRIA Unity Events";
        welcomeText.enabled = true;
        ButtonPanel.SetActive(true);
        HomeButton.enabled = false;

    }

    public void CheckTheScene()
    {
        /*  Debug.Log(SceneManager.GetActiveScene().buildIndex);
          if (SceneManager.GetActiveScene().buildIndex == 0)
          {
              InHome();
          }
          else
          {
              InScene();
          }*/
        StartCoroutine("CheckTheCurrentScene");
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    #region Coroutines
    IEnumerator CheckTheCurrentScene()
    {
        yield return new WaitForSeconds(0.01f);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            InHome();
        }
        else
        {
            InScene();
        }
    }
    #endregion
}
