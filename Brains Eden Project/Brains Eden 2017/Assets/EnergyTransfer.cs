using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnergyContainer))]
public class EnergyTransfer : MonoBehaviour {

    EnergyContainer linkedContainer;

	// Use this for initialization
	protected virtual void Start () {
        linkedContainer = GetComponent<EnergyContainer>();
	}
	
	// Update is called once per frame
	void Update () {
		// random fluctuation ???
	}

    public void drainFrom(EnergyContainer other, float strength)
    {
        if (other.changeEnergy(-strength))
        {
            linkedContainer.changeEnergy(strength);
        }
    }

    public void pushTo(EnergyContainer other, float strength)
    {
        if (other.changeEnergy(strength))
        {
            linkedContainer.changeEnergy(-strength);
        }
    }
}
