using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseClass : MonoBehaviour
{

}

public class BaseClass
{
    public float health { get; set; }
    public int ammo { get; set; }
    public float basicDamage { get; set; }

    public float pickupHP { get; set; }
    public float walkspeed { get; set; }
    public float sprintspeed { get; set; }

    public float berretaDamage { get; set; }

    public float shotgunDamage { get; set; }
    public float uziDamage { get; set; }
    public float rocketDamage { get; set; }

    public int berettaStartAmmo { get; set; }
    public int berettaMaxAmmo { get; set; }

    public int uziStartAmmo { get; set; }
    public int uziMaxAmmo { get; set; }

    public int shotgunAmmoMax { get; set; }
    public int shotgunStartAmmo { get; set; }

    public int rocketStartAmmo { get; set; }
    public int rocketmaxAmmo { get; set; }

}

public class Sprinter : BaseClass
{

    public  Sprinter()
    {
        health = 450;
        ammo = 20;
        basicDamage = 1.0f;
        pickupHP = 50;
        walkspeed = 20;
        sprintspeed = 30;
    }
}

public class Tank : BaseClass
{
    public Tank()
    {
        health = 600;
        ammo = 30;
        basicDamage = 1.0f;
        pickupHP = 50;

        uziStartAmmo = 75;
        uziMaxAmmo = 25;

        shotgunStartAmmo = 8;
        shotgunAmmoMax = 3;

        rocketStartAmmo = 4;
        rocketmaxAmmo = 5;

        berettaStartAmmo = 25;
        berettaMaxAmmo = 5;


    }
}

public class Conqueror : BaseClass
{
    public Conqueror()
    {
        health = 350;
        ammo = 20;
        basicDamage = 1.5f;
        pickupHP = 50;
        berretaDamage = 1.5f;
        shotgunDamage = 1.5f;
        uziDamage = 2.0f;
        rocketDamage = 1.4f;
    }
}