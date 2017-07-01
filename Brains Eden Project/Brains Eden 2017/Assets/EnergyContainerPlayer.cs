using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergyTransfer))]
public class EnergyContainerPlayer : EnergyContainer {

    bool alive = true;

    [SerializeField]
    protected GameObject batteryPack;

    Renderer playerRenderer;
    [SerializeField]
    GameObject sparksParticle;
    [SerializeField]
    GameObject explosionParticle;

    protected override void Start()
    {
        base.Start();
        playerRenderer = GetComponent<Renderer>();
    }

    protected override void Update()
    {
        base.Update();
        batteryPack.GetComponent<Renderer>().material.color = new Color(1-(energy/maxEnergy), (energy / maxEnergy), 0);
    }

    protected override void energyFull()
    {
        if (!alive)
            return;
        //Explode
        alive = false;
        GameObject part = Instantiate(sparksParticle);
        Destroy(part, 4.0f);
        part.transform.position = transform.position;
        StartCoroutine(explosionAnimation());
    }

    protected override void energyEmpty()
    {
        //Stop Functioning
        alive = false;
        StartCoroutine(powerdownAnimation());
    }

    IEnumerator explosionAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        //Instantiate(explosionParticle);
        GetComponent<PlayerAiming>().destroyParticle();
        Destroy(this.gameObject);
        yield return null;
    }

    IEnumerator powerdownAnimation()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<PlayerAiming>().destroyParticle();
        Destroy(this.gameObject);
        yield return null;
    }
}
