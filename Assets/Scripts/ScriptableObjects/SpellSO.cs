using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SpellSO : ScriptableObject
{
    public enum SpellType
    {
        Projectile,
        Aura,
        AOE,
        PlayerCenteredAOE
    }

    public string spellName;
    public Sprite spellIcon;
    public float spellCooldown;
    public int spellMana;
    public GameObject spellPrefab;
    public SpellType spellType;
    public float spellSpeed;
    public float spellLifetime;
    public int spellDamage;
    public int spellTick;
}
