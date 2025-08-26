using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
   
    [SerializeField] private Button backButton;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    void Update()
    {
        
        backButton.onClick.AddListener(delegate { BackToMenuClickButton(backButton); });
    }

   

    public void BackToMenuClickButton(Button button)
    {
        SceneManager.LoadScene("SceneMainMenu");
    }
    
}
