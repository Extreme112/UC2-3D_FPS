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
        if (Input.GetKeyDown(KeyCode.E)) {
            if (selectedWeapon == weapons.Length - 1) {
                selectedWeapon = 0;
            } else {
                selectedWeapon++;
            }
            SwitchWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (selectedWeapon == 0) {
                selectedWeapon = weapons.Length - 1;
            } else {
                selectedWeapon--;
            }
            SwitchWeapon();
        }
    }

    void SwitchWeapon() {
        for (int i = 0; i < weapons.Length; i++) {
            weapons[i].SetActive(false);
        }
        weapons[selectedWeapon].SetActive(true);
    }


    public void AddClipToSelectedWeapon() {
        weapons[selectedWeapon].GetComponent<Weapon>().AddClip();
    }

}
