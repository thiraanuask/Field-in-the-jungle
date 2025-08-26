using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour
{
    [SerializeField] Button BackButton;

    void Start()
    {
        BackButton.onClick.AddListener(delegate { BackButtonClick(BackButton); });
    }

    void Update()
    {
        
    }

    public void BackButtonClick(Button button)
    {
        SceneManager.UnloadSceneAsync("SceneCredits"); ;
    }
}