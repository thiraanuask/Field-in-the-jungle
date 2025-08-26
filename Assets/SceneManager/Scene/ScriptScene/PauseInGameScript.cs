using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInGameScript : MonoBehaviour
{
    //public bool CursorLocked = true;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SingletonGameApplicationManager.Instance.IsPauseMenuActive)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            //CursorLocked = false;
            SceneManager.LoadScene("ScenePause",LoadSceneMode.Additive);
            SingletonGameApplicationManager.Instance.IsPauseMenuActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && SingletonGameApplicationManager.Instance.IsPauseMenuActive)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            //CursorLocked = true;
        }
        
        //Cursor.lockState = CursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
