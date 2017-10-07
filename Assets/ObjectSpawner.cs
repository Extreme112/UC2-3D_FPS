using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public GameObject objToSpawn;
    int count;
    float delay;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnObject());
	}

    IEnumerator SpawnObject() {
        while (count > 0) {
            Instantiate(objToSpawn, transform.position, Quaternion.identity);
            count--;
            yield return new WaitForSeconds(delay);
        }
        Destroy(this.gameObject);
    }
}
