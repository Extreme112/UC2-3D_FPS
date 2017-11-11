using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Requirements for this script to work:
// - Player game object must be tagged as "Player"
// - Player (WeaponHolder) must have a function called AddClipToSelectedWeapon()
public class AmmoBox : MonoBehaviour {

    private AudioSource audioSource;
    bool used = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && !used) {
            other.BroadcastMessage("AddClipToSelectedWeapon");
            audioSource.Play();
            StartCoroutine(DeleteThis());
            used = true;
        }
    }

    IEnumerator DeleteThis() {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(this.gameObject);
    }
}
