using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCharacter : CharacterComponent
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Barrel>())
        {
            characterManager.NotifyState(CharacterManager.States.Die);
        }
    }

    public override void Die()
    {
        anim.SetTrigger("Die");
        GetComponent<CapsuleCollider>().enabled = false;
    }
    public override void DieByWall()
    {
        anim.SetTrigger("DieWall");
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public override void Restart()
    {
        anim.SetTrigger("Restart");
        GetComponent<CapsuleCollider>().enabled = true;
    }

    public override void Starting()
    {
        
    }
    
}
