using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Equations 
{
    //public static int quantityBarrels;
    public static int weaponDamage;
    public static int characterSpeed;
    public static int rateOfFire;

    public static double BarrelsLife(int quantityBarrels)
    {
        double b = 2.7f;
        double e = 0.05f;
        double c = 3 + (quantityBarrels / 20) * 0.5f;

        return System.Math.Pow(b, e * Mathf.Max(Random.Range(quantityBarrels - 5, quantityBarrels + 5), 1)) * c;
    }

    public static double WeaponDamage(float weaponDamage)
    {
        double b = 2.7f;
        double e = 0.015f;
        double c = 1 + (Equations.weaponDamage / 20) * 0.5f;

        return System.Math.Pow(b, e * Equations.weaponDamage) * c;
    }

    public static float TimeRegenerateBarrels(int quantityBarrels)
    {
        float b = 2f;
        float e = -0.01f;
        float c = 1.5f;

        return Mathf.Pow(b, e * quantityBarrels) * c;
    }

    public static float SpeedBarrels()
    {
        float b = 2f;
        float e = -0.01f;
        float c = 6; // 6

        //return Mathf.Pow(b, e * quantityBarrels) * c + 6;
        return 12;
    }

    public static float CharacterSpeed()
    {
        float b = 2f;
        float e = -0.01f;
        float c = 0.7f;

        return Mathf.Pow(b, e * characterSpeed) * c + 0.3f;
    }

    public static float RateOfFire()
    {
        float b = 2f;
        float e = -0.015f;
        float c = 0.21f;

        return Mathf.Pow(b, e * rateOfFire) * c + 0.09f;
    }

    public static void UpWeaponDamage()
    {
        weaponDamage++;
    }

    public static void UpCharacterSpeed()
    {
        characterSpeed++;
    }

    public static void UpRateOfFire()
    {
        rateOfFire++;
    }
}
