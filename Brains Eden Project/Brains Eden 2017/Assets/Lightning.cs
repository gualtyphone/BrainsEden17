using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Lightning : MonoBehaviour {

    public Material lightningMat;

    LineRenderer lineRend;
    public Vector3 endPoint;
    public Vector3 midPoint;
    public float radius;
    public int segments;
    public Color color;
    public float bezierTimer;


	// Use this for initialization
	void Start () {
        
	}

    public void ready()
    {        
        lineRend = GetComponent<LineRenderer>();
        lineRend.material = lightningMat;
        lineRend.numPositions = segments;
        int closest = (int)(bezierTimer * segments);
        for (int i = 0; i < segments; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));
            pos += (PlayerAiming.Bezier(transform.position, midPoint, endPoint, ((float)i) / ((float)segments)));
            if (i==closest)
            {
                pos += new Vector3(Random.Range(-radius*2, radius * 2), Random.Range(-radius * 2, radius * 2), Random.Range(-radius * 2, radius * 2));
            }
            if (i + 1 == closest || i - 1 == closest)
            {
                pos += new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));
            }
            lineRend.SetPosition(i, pos);
        }
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
