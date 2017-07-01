using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bob : MonoBehaviour {
    public bool up = true;
    private Vector3 startPoint;
    private float m_speed = 0.1f;


    private void Start()
    {
        startPoint = transform.position;
        up = (Random.Range(0, 2) == 1);
        //m_speed = Random.Range(0.1f, 0.5f);
    }


    void Update () {
        if (transform.position.y >= startPoint.y + 3f)
        {
            up = false;
        }
        else if (transform.position.y <= startPoint.y - 3f)
        {
            up = true;
        }
        if (up)
        {
            transform.position += new Vector3(0, m_speed, 0);
        }
        else
        {
            transform.position -= new Vector3(0, m_speed, 0);
        }
	}
}
