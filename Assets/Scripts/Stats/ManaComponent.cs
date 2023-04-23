using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaComponent : MonoBehaviour
{
    [SerializeField] private float MPMax = 1000f;
    [SerializeField] private float MPRegen = 50f;
    private float MP;

    private void Awake()
    {
        MP = MPMax;
    }

    private void Update()
    {
        MP += MPRegen * Time.deltaTime;   
    }

    public float GetMPPercent()
    {
        return MP / MPMax;
    }

    public float GetMP()
    {
        return MP;
    }

    public void UseMana(float manaCost)
    {
        MP -= manaCost;
    }

    public bool HasEnoughMana(float manaCost)
    {
        return MP >= manaCost;
    }
}
