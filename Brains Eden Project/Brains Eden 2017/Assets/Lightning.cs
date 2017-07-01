using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Lightning : MonoBehaviour {

    LineRenderer lineRend;
    public Vector3 endPoint;
    public Vector3 midPoint;
    public float radius;
    public int segments;
    public Color color;


	// Use this for initialization
	void Start () {
        
	}

    public void ready()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.numPositions = segments;
        for (int i = 0; i < segments; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));
            pos += (PlayerAiming.Bezier(transform.position, midPoint, endPoint, ((float)i) / ((float)segments)));
            lineRend.SetPosition(i, pos);
        }
        int f = 0;
    }

// Update is called once per frame
void Update () {
        color.a -= 10.0f;

        lineRend.endColor = color;
        lineRend.startColor = color;

        if (color.a <= 0.0f)
        {
            DestroyImmediate(this.gameObject);
        }
       
	}
}
