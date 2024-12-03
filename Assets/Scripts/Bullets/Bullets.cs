using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullets : MonoBehaviour
{
    float speed;
    float damage;
    public Rigidbody rb;
    public void SetBullet(float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
    }

    public void Shoot()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while(gameObject.activeInHierarchy)
        {
            //transform.Translate(Vector3.forward * speed * TimeManager.control.GetBulletTime(),Space.World);
            rb.MovePosition(rb.position + Vector3.forward * speed * TimeManager.control.GetBulletTime());

            if (transform.position.z > 70)
                gameObject.SetActive(false);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrel>())
        {
            gameObject.SetActive(false);
            other.GetComponent<Barrel>().ReduceLife(Math.Round(Equations.WeaponDamage(damage)));
        }
    }
}
