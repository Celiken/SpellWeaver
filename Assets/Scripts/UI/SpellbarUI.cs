using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbarUI : MonoBehaviour
{
    [SerializeField] private SpellSO[] spellList;
    [SerializeField] private GameObject spellTemplate;
    [SerializeField] private Transform spellParent;

    // Start is called before the first frame update
    void Start()
    {
        int spellSlot = 1;
        foreach (SpellSO spell in spellList)
        {
            GameObject spellGameObject = Instantiate(spellTemplate, spellParent);
            spellGameObject.SetActive(true);
            SpellUI spellObj = spellGameObject.GetComponent<SpellUI>();
            spellObj.SetSpell(spell, spellSlot);
            spellSlot++;
        }
    }
}
