using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CharacterComponent
{
    public Pool bullets;

    public Transform startBullet;

    public float currentBulletSpeed;

    public float rateOfFire;

    public float currentDamage;

    Coroutine shooting;

    public void Set(float initDamage)
    {
        currentDamage = initDamage;
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
            yield return new WaitForSeconds(Equations.RateOfFire());
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
        shooting = StartCoroutine(RateOfFire());
    }

    public override void DieByWall()
    {
        StopCoroutine(shooting);
    }
}
