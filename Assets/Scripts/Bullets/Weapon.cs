using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CharacterComponent
{
    public Pool bullets;

    public Transform startBullet;

    public float currentBulletSpeed;

    public int rateOfFire; 

    public int currentDamage;

    Coroutine shooting;

    public void SetUp()
    {
        currentDamage = GameControl.instance.GetData(ProgressManager.PlayerData.WeaponType.Pistol, ProgressManager.PlayerData.WeaponFeature.Damage);
        rateOfFire = GameControl.instance.GetData(ProgressManager.PlayerData.WeaponType.Pistol, ProgressManager.PlayerData.WeaponFeature.RateOfFire);
    }

    public void Shot()
    {
        Bullets bullet = bullets.GetPooledObject().GetComponent<Bullets>();
        bullet.SetBullet(currentBulletSpeed, currentDamage);
        bullet.transform.position = startBullet.position;
        bullet.Shoot();
    }

    IEnumerator RateOfFire()
    {
        while (true)
        {
            Shot();
            yield return new WaitForSeconds(Equations.RateOfFire(rateOfFire));
        }
    }

    public override void Die()
    {
        StopCoroutine(shooting);
    }

    public override void Restart()
    {

    }

    public override void Starting()
    {
        SetUp();
        shooting = StartCoroutine(RateOfFire());
    }

    public override void DieByWall()
    {
        Die();
    }
}
