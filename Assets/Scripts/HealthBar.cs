using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform healthBar;
    public Slider healthFill;
    // Update is called once per frame
    void Update()
    {
        PositionHealthBar();
    }

    public void ChangeHealth(float currentHealth, float maxHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthFill.value = currentHealth / maxHealth;   
    }

    private void PositionHealthBar()
    {
        Vector3 currentPos = transform.position;

        healthBar.position = new Vector3(currentPos.x,
            currentPos.y + 2, currentPos.z);

        healthBar.LookAt(Camera.main.transform);
    }

}
