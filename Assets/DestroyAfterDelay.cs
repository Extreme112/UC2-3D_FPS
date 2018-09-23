using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour {

    public int delayInSeconds;

	// Use this for initialization
	void Start () {
        StartCoroutine(DelayDestroy());
	}


    IEnumerator DelayDestroy() {
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(this.gameObject);
    }
}
