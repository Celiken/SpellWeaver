using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AOESpell : BaseSpell
{
    [SerializeField] AOESpellSO spellSO;
    private List<Collider> triggerList = new List<Collider>();
    private float timeUntilNextTick;

    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(spellSO.spellLifetime));
        timeUntilNextTick = 0.1f;
    }

    private void Update()
    {
        timeUntilNextTick -= Time.deltaTime;
        if (timeUntilNextTick <= 0f)
        {
            timeUntilNextTick = spellSO.spellLifetime / spellSO.spellTick;
            TickDamage();
        }
    }

    public void SetSpellSO(AOESpellSO spellSO)
    {
        this.spellSO = spellSO;
    }

    private void TickDamage()
    {
        triggerList = triggerList.Where(c => c != null).ToList();
        foreach (var collider in triggerList)
            collider.GetComponent<Enemy>().GetHit(spellSO.spellDamage);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagConstants.ENEMY) && triggerList.Contains(other))
            triggerList.Remove(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConstants.ENEMY) && !triggerList.Contains(other))
            triggerList.Add(other);
    }

}
