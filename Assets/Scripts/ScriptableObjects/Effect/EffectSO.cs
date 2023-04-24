using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSO : ScriptableObject
{
    public enum EffectType
    {
        Debuff,
        Buff,
        HoT,
        DoT
    }

    public Transform effectPrefab;
    public string effectName;
    public float effectLifetime;
}
