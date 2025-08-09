using System;
using UnityEngine;

public static class Equations 
{
    //public static int quantityBarrels;
    public static int weaponDamage;
    public static int characterSpeed;
    public static int rateOfFire;

    public static long GetRandomLong(long min, long max)
    {
        // Asegura que min sea menor que max
        if (min > max)
        {
            long temp = min;
            min = max;
            max = temp;
        }

        // Usa Random para crear el número aleatorio
        System.Random rand = new System.Random();

        // La diferencia puede ser muy grande, así que usamos ulong para manejarla
        ulong range = (ulong)(max - min);
        byte[] buffer = new byte[8];
        rand.NextBytes(buffer);
        ulong randValue = BitConverter.ToUInt64(buffer, 0);

        // Lo reducimos al rango deseado
        long result = (long)(randValue % range) + min;
        return result;
    }

    public static long BarrelsLife(long quantityBarrels)
    {
        int random = UnityEngine.Random.value < 0.5f ? -1 : 1;

        double result = quantityBarrels + random > 0? + quantityBarrels/2 : - quantityBarrels / 2;

        return Math.Max((long)result, 3);
    }

    public static long WeaponDamage(long weaponDamage)
    {
        double b = 2.7f;
        double e = 0.015f;
        double c = 1 + (Equations.weaponDamage / 20) * 0.5f;

       // Debug.Log("Weapon Damage equation value: " + System.Math.Pow(b, e * Equations.weaponDamage) * c);

        double result = System.Math.Pow(b, e * Equations.weaponDamage) * c;

        //return (long)result;
        return weaponDamage;
    }

    public static float TimeRegenerateBarrels(long quantityBarrels)
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

    public static long Cost(int basePrice, ProgressManager.PlayerData.WeaponType weaponType)
    {
        float baseP = basePrice;
        float exponent = 0.2f;
        float constant = 9;
        float x = GameControl.instance.GetData(weaponType);


        return (long)(Mathf.Pow(baseP, exponent * x) + constant);

    }
        

    public static void UpWeaponDamage()
    {
        //Debug.Log("Weapon Damage var value: " + weaponDamage);
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
