using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string wepName;
    public int damage;
    public GameObject oCamera;
    public float range;
    //reload speed, fireRate, ammo count

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //----SHOOOTING------------
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(oCamera.transform.position, oCamera.transform.forward, out hit, range)) {
                print(hit.transform.name);
                print(hit.collider.gameObject.name);
                //  ----------Deal damage to an enemy-------
                if (hit.collider.CompareTag("Enemy")) {
                    EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDamage(damage);
                }
                //---------------------------------------------------
            }
        }
        //-----------------
        
    }
}
