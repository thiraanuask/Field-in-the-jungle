using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button optionsButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button creditsButton;
    
    void Start()
    {
        optionsButton.onClick.AddListener(delegate { OptionsButtonClick(optionsButton); });
        exitButton.onClick.AddListener(delegate { ExitButtonClick(exitButton); });
        creditsButton.onClick.AddListener(delegate { CreditsButtonClick(creditsButton); });
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        
    }

    public void OptionsButtonClick(Button button)
    {
        if (!SingletonGameApplicationManager.Instance.IsOptionsMenuActive)
        {
            SceneManager.LoadScene("SceneOptions", LoadSceneMode.Additive);
            SingletonGameApplicationManager.Instance.IsOptionsMenuActive = true;
        }
    }

    public void CreditsButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneCredits", LoadSceneMode.Additive);
    }

    public void ExitButtonClick(Button button)
    {
        Application.Quit();
    }
}
