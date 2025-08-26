using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangLevel : MonoBehaviour
{
    [Header("Settings NextLevel")]
    public int NextsceneLevel;

    [Header("ScriptableObject")]
    public IntegerVariable hp;
    public IntegerVariable currentAmmo;
    public IntegerVariable ammoInventory;

    [Header("OldScriptableObject")]
    public IntegerVariable hpOld;
    public IntegerVariable currentAmmoOld;
    public IntegerVariable ammoInventoryOld;

    public void OldSettings()
    {
        //Save ScriptableObject
        hpOld.Value = hp.Value;
        currentAmmoOld.Value = currentAmmo.Value;
        ammoInventoryOld.Value = ammoInventory.Value;
    }
    
    public void NextLevelLoad()
    {
        //LoadSecne
        StartCoroutine(LoadAsynchronously());
    }
    
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(NextsceneLevel);
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            yield return null;
        }
    }
}
