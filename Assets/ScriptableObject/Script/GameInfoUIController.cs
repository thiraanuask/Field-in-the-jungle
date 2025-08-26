using System.Collections;
using System.Collections.Generic;
using LastHopeStudio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameInfoUIController : MonoBehaviour
{
    [Header("Show BulletUI")]
    [SerializeField] protected IntegerVariable bulletAmmo;
    [SerializeField] protected IntegerVariable currentAmmo;
    [SerializeField] protected TextMeshProUGUI uiTextCurrentAmmo;
    [SerializeField] protected TextMeshProUGUI uiTextAmmoInvertory;
    
    [Header("Show StaminaUI")]
    [SerializeField] protected FloatVariable myStamina;
    [SerializeField] protected Slider sliderStamina;
    
    void Start()
    {
        uiTextCurrentAmmo.text = currentAmmo.Value.ToString();
        uiTextAmmoInvertory.text =  "/" + bulletAmmo.Value.ToString();
        sliderStamina.value = myStamina.Value;
    }
    
    void Update()
    {
        UpdateAmmoToUi();
        UpdateCurrentStamina();
    }

    public void UpdateAmmoToUi()
    {
        uiTextCurrentAmmo.text = currentAmmo.Value.ToString();
        uiTextAmmoInvertory.text = "/" + bulletAmmo.Value.ToString();
    }

    public void UpdateCurrentStamina()
    {
        sliderStamina.value = myStamina.Value;
    }
}
