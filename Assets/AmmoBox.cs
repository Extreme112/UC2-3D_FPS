﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.SendMessage("AddClipToSelectedWeapon");
        }
        Destroy(this.gameObject);
    }

}
