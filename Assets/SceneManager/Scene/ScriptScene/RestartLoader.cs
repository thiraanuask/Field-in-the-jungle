using System;
using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class RestartLoader : MonoBehaviour
{
    [Header("ScriptableObject")]
    public IntegerVariable hp;
    public IntegerVariable currentAmmo;
    public IntegerVariable ammoInventory;
    public IntegerVariable restartLevel;
    
    [Header("OldScriptableObject")]
    public IntegerVariable hpOld;
    public IntegerVariable currentAmmoOld;
    public IntegerVariable ammoInventoryOld;

    public AudioSource audioSource;
    public AudioClip easterEggsSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        float ran = Random.Range(0f, 100f);

        if (ran > 90f)
        {
            audioSource.PlayOneShot(easterEggsSound);
        }
    }

    public void RestartLoad()
    {
        //Restart ScriptableObjectsOld
        hp.Value = hpOld.Value;
        currentAmmo.Value = currentAmmoOld.Value;
        ammoInventory.Value = ammoInventoryOld.Value;
        Cursor.lockState = CursorLockMode.Locked;
        
        //StartLoadScene
        StartCoroutine(LoadAsynchronously());
    }
    
    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(restartLevel.Value);
        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/.9f);
            yield return null;
        }
    }
}
