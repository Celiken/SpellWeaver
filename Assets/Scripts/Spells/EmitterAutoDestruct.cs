using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterAutoDestruct : MonoBehaviour
{
    private ParticleSystem emitter;
    private bool detached = false;

    private void Awake()
    {
        emitter = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (detached && emitter.particleCount == 0)
            Destroy(gameObject);
    }

    public void DetachFromParent()
    {
        detached = true;
        transform.parent = null;
        var emission = emitter.emission;
        emission.rateOverDistance = 0;
        emission.rateOverTime = 0;
    }
}
