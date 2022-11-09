using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Color low;
    public Color high;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //place health bar above enemy with offset
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        //Only show health bar when enemy takes damage
        healthSlider.gameObject.SetActive(health < maxHealth);
        //Set health slider variable values
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;
        //Set colour of health bar, normalized value provides percentage between the two colours
        healthSlider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, healthSlider.normalizedValue);
    }
}
