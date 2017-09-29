using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public string wepName;
    public int damage;
    public Camera mainCamera;
    public float range;
    public GameObject impactEffect;

    private void Start() {

    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range)) {
                print(hit.transform.name);
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                print(hit.collider.gameObject.name);
            }
        }
    }
}
