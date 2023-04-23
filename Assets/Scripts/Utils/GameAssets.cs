using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Prefabs")]
    public Transform pfDamagePopup;

    [Header("Fonts")]
    public Material fontDefault;
    public Material fontDamageTaken;
    public Material fontDamageDeal;
}
