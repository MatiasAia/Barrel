using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CharacterComponent
{
    public Pool bullets;

    public Transform startBullet;

    public float currentBulletSpeed;

    public float rateOfFire; //TODO: implementar esta variable en las ecuaciones

    public long currentDamage;

    Coroutine shooting;

    private void Start()
    {
        currentDamage = GameControl.instance.GetData(ProgressManager.PlayerData.WeaponType.Pistol);
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
        Die();
    }
}
