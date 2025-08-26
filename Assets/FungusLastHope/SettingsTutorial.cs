using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using UnityEngine;

public class SettingsTutorial : MonoBehaviour
{
    public IntegerVariable currentBullets;
    public IntegerVariable bulletInventory;
    public IntegerVariable hp;
    
    void Start()
    {
        currentBullets.Value = 0;
        bulletInventory.Value = 0;
        hp.Value = 100;
    }

    void TutorialHealth()
    {
        hp.Value = 25;
    }
}
