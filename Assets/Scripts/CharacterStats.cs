using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth;
    public float remainingHealth;
    public float PickupHP;

    public int ammunitionAmmount;
    public int remaingAmmunition;
    public int maximumAmmunition;

    public float damage;
    public float speed;
    public int points;

    public bool isBox;
    public bool isMelee;
    public bool isWithinRange;
    public string sound;
    public string gunSound;
    public bool isBoss;
    private void Start()
    {
      remainingHealth = maxHealth;
    }
}
