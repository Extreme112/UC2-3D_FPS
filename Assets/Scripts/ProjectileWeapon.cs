using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon :  MonoBehaviour {
    public GameObject projectilePrefab;
    public string wepName;
    public float reloadDelay;
    public int ammoCount;

    private bool canFire = true;

    public GameObject mainCamera;
    public float projectileSpeed;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && canFire && ammoCount > 0) {
            GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * projectileSpeed, ForceMode.Force);
            Reload();
        }
	}

    IEnumerator Reload() {
        if (ammoCount > 0) {
            canFire = false;
            ammoCount--;
            yield return new WaitForSeconds(reloadDelay);
            canFire = true;
        }
    }
}
