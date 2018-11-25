using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineControll : MonoBehaviour {

    public GameObject[] Engines;
    public GameObject Cover;

	// Use this for initialization
	void Start () {

        Engines = GameObject.FindGameObjectsWithTag("Engine");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
