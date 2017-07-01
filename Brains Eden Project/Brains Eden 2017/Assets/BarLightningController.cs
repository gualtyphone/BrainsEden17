using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLightningController : MonoBehaviour {

    [SerializeField]
    GameObject LightningEnd;

	// Use this for initialization
	void Start () {
        GetComponent<LightningSpawner>().endPoint = LightningEnd.transform.position;
        GetComponent<LightningSpawner>().midPoint = (transform.position + LightningEnd.transform.position)/2;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
