﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawner : MonoBehaviour {

    [SerializeField]
    GameObject LightningPrefab;

    [SerializeField]
    Material[] LightningMats;

    public Vector3 endPoint;
    public Vector3 midPoint;
    public float radius;
    public int segments;
    public Color color;
    public float bezierTimer;

    // Use this for initialization
    void Start () {
        radius = 0.4f;
        segments = 12;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = Instantiate(LightningPrefab);
            go.GetComponent<Lightning>().endPoint = endPoint;
            go.GetComponent<Lightning>().midPoint = midPoint;
            go.GetComponent<Lightning>().radius = radius;
            go.GetComponent<Lightning>().segments = segments;
            go.GetComponent<Lightning>().color = color;
            go.GetComponent<Lightning>().bezierTimer = bezierTimer;
            //go.GetComponent<Lightning>().lightningMat = LightningMats[GetComponentInParent<PlayerController>().playerNumber-1];
            go.transform.position = transform.position;
            go.transform.parent = this.transform;
            go.GetComponent<Lightning>().ready();
        }
    }
}
