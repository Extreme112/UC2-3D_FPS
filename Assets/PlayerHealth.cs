using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    int maxHealth = 100;
    int currentHealth;

    //Sound Stuff
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
	}

    public void TakeDamage(int dmg) {
        currentHealth -= dmg;
        audioSource.Play();
        if (currentHealth <= 0) {
            //What do we do when player dies? Put code here.
            SceneManager.LoadScene("GameScene");
        }
    }
}
