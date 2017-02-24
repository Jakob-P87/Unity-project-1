using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeTrigger : MonoBehaviour {

    GameObject player;

  private float damage = 50.0f;
 
void Start()
    {
        Physics.IgnoreCollision(collider, player.collider);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent(EnemyDamage))
        {
            other.gameObject.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            gameObject.active = false;
        }

    }
}

