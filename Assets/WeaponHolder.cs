using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    public GameObject[] weapons; //this will hold our weapons
    int selectedWeapon = 0; //this is our default weapon
	// Use this for initialization
	void Start () {
        SwitchWeapon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SwitchWeapon() {
        for (int i = 0; i < weapons.Length; i++) {
            weapons[i].SetActive(false);
        }
        weapons[selectedWeapon].SetActive(true);
    }
}
