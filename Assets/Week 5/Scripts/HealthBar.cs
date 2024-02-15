using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        UpdateHealth(PlayerPrefs.GetFloat("KnightHealth", slider.maxValue));
    }

    public void UpdateHealth(float health)
    {
        slider.value = Mathf.Clamp(health, slider.minValue, slider.maxValue);
    }
}
