using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameApplicationManager : Singleton<SingletonGameApplicationManager>
{
    //OptionsMenu
    public bool IsOptionsMenuActive
    {
        get { return isOptionsMenuActive;}
        set { isOptionsMenuActive = value; }
    }

    protected bool isOptionsMenuActive = false;

    //PuaseMenu
    public bool IsPauseMenuActive
    {
        get { return isPuaseMenuActive;}
        set { isPuaseMenuActive = value; }
    }

    protected bool isPuaseMenuActive = false;
    
    //KeyLockMenu
    public bool IsKeyLockMenuActive
    {
        get { return isKeyLockMenuActive;}
        set { isKeyLockMenuActive = value; }
    }

    protected bool isKeyLockMenuActive = false;
    
    //Toggle Singleton
    public bool MasterEnable { get; set; } = true;
    public bool MusicEnable { get; set; } = true;
    public bool SFXEnable { get; set; } = true;

    //Slider Singleton
    public float MasterValue { get; set; } = 1;
    public float MusicValue { get; set; } = 1;
    public float SFXValue { get; set; } = 1;

}
