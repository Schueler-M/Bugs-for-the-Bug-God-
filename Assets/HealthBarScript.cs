using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Image HealthSprite;

    public void UpdateHealth(float totalHealth, float curHealth)
    {
        HealthSprite.fillAmount = curHealth / totalHealth; // Setting the health percentage
    }
}
