using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //allows us to switch/reload scenes

public class PlayerHealth : MonoBehaviour {
    int maxHealth = 100;
    int currentHealth;
    //Sound effects
    public AudioClip hurtSound;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmg) {
        currentHealth -= dmg; //currentHealth = currentHealth - dmg;
        audioSource.clip = hurtSound;
        audioSource.Play();
        if (currentHealth <= 0) {
            //Death handling code
            //play a death sound, play a death animation, subract lives
            SceneManager.LoadScene("GameScene"); //eventually go back to start screen
        }
    }
}