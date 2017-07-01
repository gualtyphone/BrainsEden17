using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWob : MonoBehaviour {
    private Vector3 Scale;
    private bool Incress = false;
    public Vector3 wobSpeed;
	void Update () {
        if (transform.localScale.x >= 1)
        {
            Incress = false;
        }
        else if (transform.localScale.x <= 0.3)
        {
            Incress = true;
        }

        if (Incress)
        {
            transform.localScale += wobSpeed;
        }
        else
        {
            transform.localScale -= wobSpeed;
        }
	}
}
