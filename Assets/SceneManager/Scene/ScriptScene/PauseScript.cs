using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button backButton;

    void Start()
    {
        resumeButton.onClick.AddListener(delegate { ResumeButtonClick(resumeButton); });
        optionsButton.onClick.AddListener(delegate { OptionsButtonClick(optionsButton); });
        backButton.onClick.AddListener(delegate { BackButtonClick(backButton); });
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SingletonGameApplicationManager.Instance.IsPauseMenuActive)
        {
            SceneManager.UnloadSceneAsync("ScenePause");
            if (SingletonGameApplicationManager.Instance.IsOptionsMenuActive)
            {
                SceneManager.UnloadSceneAsync("SceneOptions");
                SingletonGameApplicationManager.Instance.IsOptionsMenuActive = false;
            }
            SingletonGameApplicationManager.Instance.IsPauseMenuActive = false;
        }
    }

    public void ResumeButtonClick(Button button)
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.UnloadSceneAsync("ScenePause");
        SingletonGameApplicationManager.Instance.IsPauseMenuActive = false;
        SingletonGameApplicationManager.Instance.IsKeyLockMenuActive = false;
    }

    public void OptionsButtonClick(Button button)
    {
        SceneManager.LoadScene("SceneOptions",LoadSceneMode.Additive);
        SingletonGameApplicationManager.Instance.IsOptionsMenuActive = true;
    }

    public void BackButtonClick(Button button)
    {
        Time.timeScale = 1;
        SingletonGameApplicationManager.Instance.IsPauseMenuActive = false;
        SingletonGameApplicationManager.Instance.IsKeyLockMenuActive = false;
    }
    
}
