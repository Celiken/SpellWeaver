using UnityEngine;
using UnityEngine.UI;

public class SpellSO : ScriptableObject
{
    public enum SpellType
    {
        Projectile,
        AOE,
        PlayerCenteredAOE
    }

    public string spellName;
    public Sprite spellIcon;
    public float spellCooldown;
    public int spellMana;
    public GameObject spellPrefab;
    public SpellType spellType;
    public float spellLifetime;
    public int spellDamage;
}
