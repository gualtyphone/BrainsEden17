using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	public void deathTimerStart () {  Destroy(gameObject, 0.5f);
	}
	
}
