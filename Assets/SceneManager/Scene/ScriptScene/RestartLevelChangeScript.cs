using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using UnityEngine;

public class RestartLevelChangeScript : MonoBehaviour
{
    [Header("Settings Restart")] 
    public int restartLevel;

    [Header("ScriptObjectsable")] 
    public IntegerVariable restart;
    void Start()
    {
        restart.Value = restartLevel;
    }
}
