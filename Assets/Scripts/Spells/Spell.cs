using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [SerializeField] private SpellSO spellSO;
    [SerializeField] private ParticleSystem emitter;

    private List<Collider> triggerList = new List<Collider>();

    private float timeUntilNextTick;

    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(spellSO.spellLifetime));
        timeUntilNextTick = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (spellSO.spellType == SpellSO.SpellType.Projectile)
        {
            transform.Translate(Vector3.forward * spellSO.spellSpeed * Time.deltaTime);
        } else if (spellSO.spellType == SpellSO.SpellType.AOE)
        {
            timeUntilNextTick -= Time.deltaTime;
            if (timeUntilNextTick <= 0f)
            {
                TickDamage();
                timeUntilNextTick = spellSO.spellLifetime / spellSO.spellTick;
            }
        }
    }

    public void SetSpellSO(SpellSO spellSO)
    {
        this.spellSO = spellSO;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(TagConstants.PLAYER) && !other.CompareTag(TagConstants.SPELL))
        {
            if (spellSO.spellType == SpellSO.SpellType.Projectile)
            {
                if (other.CompareTag(TagConstants.ENEMY))
                {
                    other.GetComponent<Enemy>().GetHit(spellSO.spellDamage);
                }
                StartCoroutine(ExecuteAfterTime(0f));
            }
            else if (spellSO.spellType == SpellSO.SpellType.AOE)
            {
                if (other.CompareTag(TagConstants.ENEMY) && !triggerList.Contains(other))
                {
                    triggerList.Add(other);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(TagConstants.PLAYER) && !other.CompareTag(TagConstants.SPELL))
        {
            if (spellSO.spellType == SpellSO.SpellType.AOE)
            {
                if (other.CompareTag(TagConstants.ENEMY) && triggerList.Contains(other))
                {
                    triggerList.Remove(other);
                }
            }
        }
    }

    private void TickDamage()
    {
        triggerList = triggerList.Where(c => c != null).ToList();
        foreach (var collider in triggerList)
        {
            collider.GetComponent<Enemy>().GetHit(spellSO.spellDamage);
        }
    }

    IEnumerator ExecuteAfterTime(float time)
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
