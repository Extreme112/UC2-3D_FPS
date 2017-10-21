using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour {
    public int damage;

    private void OnCollisionEnter(Collision collision) {
        GameObject go = collision.other.gameObject;
        if (go.CompareTag("Player")) {  //if enemy touches player
            //deal damage to player
            PlayerHealth pH = go.GetComponent<PlayerHealth>();
            pH.TakeDamage(damage); //enemy deals damage to player
            Destroy(gameObject); //enemy suicides
        }
    }
}
