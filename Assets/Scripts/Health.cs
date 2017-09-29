using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;

    public void DealDamage(int dmg) {
        health -= dmg;

        if (health <= 0) {
            Destroy(this.gameObject);
        }
    }
}
