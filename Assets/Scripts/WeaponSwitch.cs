using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
    public GameObject[] weapons;
    int selectedWeapon = 0;
	// Use this for initialization
	void Start () {
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (selectedWeapon == weapons.Length - 1) {
                selectedWeapon = 0;
            } else {
                selectedWeapon++;
            }
            SelectWeapon(); //SwitchWeapon
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (selectedWeapon == 0) {
                selectedWeapon = weapons.Length - 1;
            } else {
                selectedWeapon--;
            }
            SelectWeapon();
        }
	}

    void SelectWeapon() {
        for (int i = 0; i < weapons.Length; i++) {
            weapons[i].SetActive(false);
        }
        weapons[selectedWeapon].SetActive(true);
    }
}
