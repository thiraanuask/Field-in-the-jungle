using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using UnityEngine;

public class GodModeScript : MonoBehaviour
{
    public IntegerVariable ammoInventory;
    public bool isGodMode = false;
    public GameObject[] gameObjectGodMode;

    void Update()
    {
        ActivateGodMode();
    }

    void ActivateGodMode()
    {
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.H) && !isGodMode)
        {
            isGodMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.H) && isGodMode)
        {
            isGodMode = false;
        }

        if (isGodMode)
        {
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                ammoInventory.Value += 20;
            }
            
            foreach (var gameObjects in gameObjectGodMode)
            {
                gameObjects.SetActive(true);
            }
        }
        else
        {
            foreach (var gameObjects in gameObjectGodMode)
            {
                gameObjects.SetActive(false);
            }
        }
    }
}
