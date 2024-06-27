using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;

    public void SetMaxHealth(int health) 
    {
        healthBarFill.fillAmount = 1f;
    }

    public void SetHealth(int health, int maxHealth) 
    {
        healthBarFill.fillAmount = (float)health/maxHealth;
    }
}
