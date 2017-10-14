
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour {
    public int attackValue;
    private void OnCollisionEnter(Collision collision) {
        GameObject go = collision.gameObject; //the thing the enemy touches
        if (go.CompareTag("Player")) {
            //deal damage to the player
            PlayerHealth playerHealth = go.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(attackValue);
            Destroy(this.gameObject); //Makes the enemy act like a creeper from Minecraft
        }
    }
}