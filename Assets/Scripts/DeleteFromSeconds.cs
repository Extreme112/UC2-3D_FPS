using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFromSeconds : MonoBehaviour {
    public float delay;

    // Use this for initialization
    void Start() {
        Invoke("DestroyThis", delay);
    }

    private void DestroyThis() {
        Destroy(this.gameObject);
    }
}
