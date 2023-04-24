using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseSpell : MonoBehaviour
{
    [SerializeField] protected ParticleSystem emitter;

    protected IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        DetachParticle();
        Destroy(gameObject);
    }

    private void DetachParticle()
    {
        emitter.GetComponent<EmitterAutoDestruct>().DetachFromParent();
    }
}
