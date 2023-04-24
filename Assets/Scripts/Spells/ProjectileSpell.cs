using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProjectileSpell : BaseSpell
{
    [SerializeField] ProjectileSpellSO spellSO;

    private void Start()
    {
        StartCoroutine(ExecuteAfterTime(spellSO.spellLifetime));
    }

    private void Update()
    {
        if (spellSO.spellType == SpellSO.SpellType.Projectile)
            transform.Translate(Vector3.forward * spellSO.spellSpeed * Time.deltaTime);
    }

    public void SetSpellSO(ProjectileSpellSO spellSO)
    {
        this.spellSO = spellSO;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(TagConstants.PLAYER) && !other.CompareTag(TagConstants.SPELL))
        {
            if (other.CompareTag(TagConstants.ENEMY))
                other.GetComponent<Enemy>().GetHit(spellSO.spellDamage);
            StartCoroutine(ExecuteAfterTime(0f));
        }
    }

}
