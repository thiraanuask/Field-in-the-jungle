using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using UnityEngine;

public class SettingLevelScript : MonoBehaviour
{
    [Header("Settings Levels")] 
    public int healthPoint;
    public int currentBullet;
    public int bulletsInventory;

    [Header("ScriptableObject")]
    public IntegerVariable hp;
    public IntegerVariable currentAmmo;
    public IntegerVariable ammoInventory;

    void Start()
    {
        hp.Value = healthPoint;
        currentAmmo.Value = currentBullet;
        ammoInventory.Value = bulletsInventory;
    }
    
}
