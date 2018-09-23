using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour {
    public GameObject projectilePrefab; //this is the actual thing your rocket launcher will shoot
    public string wepName;
    public float reloadDelay;     //our rocket launchers will be single shot only
    public int ammoCount;    //ammo in our case is the number of rockets you have
    public int speed; //speed of the projectile prefab
    public GameObject mainCamera; //this a the main camera

    private bool canFire = true;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0 && canFire == true) {
            GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * speed, ForceMode.Force);
            StartCoroutine(Reload());
        }
	}

    IEnumerator Reload() {
        canFire = false; //prevent the player from firing
        ammoCount--; //subtract ammo
        yield return new WaitForSeconds(reloadDelay); //wait a few seconds...
        canFire = true; //before letting the player fire again
    }
}
