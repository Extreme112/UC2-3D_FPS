using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  //FOR UI

public class PlayerHealth : MonoBehaviour {
    int maxHealth = 100;
    int currentHealth;

    public Slider healthSlider; //Need to access the slider

    //Sound Stuff
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
        /////////////////////////
        healthSlider.minValue = 0;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int dmg) {
        currentHealth -= dmg;
        healthSlider.value = currentHealth; //update the sliders value
        audioSource.Play();
        if (currentHealth <= 0) {
            //What do we do when player dies? Put code here.
            SceneManager.LoadScene("Menu");
        }
    }
}
