using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class DebuffEffectSO : EffectSO
{
    public enum DebuffType
    {
        Damage,
        Armor,
        Status,
        Speed,
    }

    public float effectMultiplier;
}
