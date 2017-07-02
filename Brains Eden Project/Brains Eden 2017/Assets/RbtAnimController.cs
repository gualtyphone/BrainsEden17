using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbtAnimController : MonoBehaviour {

	[SerializeField]
	GameObject LeftShoulder;
	[SerializeField]
	GameObject RightShoulder;
	[SerializeField]
	GameObject Neck;

	public bool shootingL; 
	public bool shootingR; 

	public Vector3 targetDirection;
	public bool walking;
	public Vector3 walkingDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (shootingL)
		{
			LeftShoulder.transform.LookAt(LeftShoulder.transform.position + transform.forward);
		}
		else
		{
			LeftShoulder.transform.LookAt(LeftShoulder.transform.position + -(transform.up));
		}

		if (shootingR)
		{
			RightShoulder.transform.LookAt(RightShoulder.transform.position + transform.forward);
		}
		else
		{
			RightShoulder.transform.LookAt(RightShoulder.transform.position + -(transform.up));
		}
		/*if (shooting)
		{
			float rotation = Mathf.Atan2(targetDirection.x, targetDirection.z)*180/Mathf.PI;
			if (rotation >0 && rotation <= 90)
			{
				RightShoulder.transform.LookAt(RightShoulder.transform.position + targetDirection.normalized);
				LeftShoulder.transform.LookAt(LeftShoulder.transform.position + Vector3.down);
			}
			else if (rotation >270 && rotation <= 360)
			{
				LeftShoulder.transform.LookAt(LeftShoulder.transform.position + targetDirection.normalized);
				RightShoulder.transform.LookAt(RightShoulder.transform.position + Vector3.down);
			}
			else if (rotation >90 && rotation <= 180)
			{
				transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
				RightShoulder.transform.LookAt(RightShoulder.transform.position + targetDirection.normalized);
				LeftShoulder.transform.LookAt(LeftShoulder.transform.position + Vector3.down);
			}
			else if (rotation >180 && rotation <= 270)
			{
				LeftShoulder.transform.LookAt(LeftShoulder.transform.position + targetDirection.normalized);
				RightShoulder.transform.LookAt(RightShoulder.transform.position + Vector3.down);
			}
		}
		else
		{
			RightShoulder.transform.LookAt(RightShoulder.transform.position + Vector3.down);
			LeftShoulder.transform.LookAt(LeftShoulder.transform.position + Vector3.down);
		}*/

	}
}
