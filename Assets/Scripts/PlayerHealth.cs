using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    int maxHealth = 100;
    int currentHealth;

    public Slider healthSlider;

    //Sound Stuff
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        healthSlider.maxValue = maxHealth;
        healthSlider.minValue = 0;
        healthSlider.value = currentHealth;
	}

    public void TakeDamage(int dmg) {
        currentHealth -= dmg;
        audioSource.Play();
        healthSlider.value = currentHealth; //update the slider
        print("currentHealth" + currentHealth);
        if (currentHealth <= 0) {
            //What do we do when player dies? Put code here.
            SceneManager.LoadScene("Menu");
        }
    }
}
