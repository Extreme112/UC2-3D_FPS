using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //allows us to use AI

public class AIMove : MonoBehaviour {

    NavMeshAgent nav;       //setup of AI Movement
    GameObject player;
	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>(); //setup of AI Movement
        player = GameObject.FindGameObjectWithTag("Player"); //make sure to Tag 
        //set the enemy's destination to the players position
        nav.SetDestination(player.transform.position); 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
