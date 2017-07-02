using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPlatformPower : MonoBehaviour {

    [SerializeField]
    Material standard;
    [SerializeField]
    Material red;
    [SerializeField]
    Material green;

    [SerializeField]
    GameObject plusEmitter;
    [SerializeField]
    GameObject minusEmitter;

    int currentMode;

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = standard;
        plusEmitter.SetActive(false);
        minusEmitter.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0.0f, 1000.0f) < 1)
        {
            changeMode();
        }
        
	}

    void changeMode()
    {
        int result = Random.Range(1, 3);
        switch (result)
        {
            case 0:
                GetComponent<Renderer>().material = standard;
                plusEmitter.SetActive(false);
                minusEmitter.SetActive(false);
                break;
            case 1:
                GetComponent<Renderer>().material = red;
                plusEmitter.SetActive(false);
                minusEmitter.SetActive(true);
                break;
            case 2:
                GetComponent<Renderer>().material = green;
                plusEmitter.SetActive(true);
                minusEmitter.SetActive(false);
                break;
        }
        currentMode = result;
    }

    private void OnTriggerStay(Collider other)
    {
        switch (currentMode)
        {
            case 0:
                break;
            case 1:
                if (other.GetComponent<EnergyContainer>())
                {
                    other.GetComponent<EnergyContainer>().changeEnergy(-0.2f);
                }
                break;
            case 2:
                if (other.GetComponent<EnergyContainer>())
                {
                    other.GetComponent<EnergyContainer>().changeEnergy(0.2f);
                }
                break;
        }
    }
}
