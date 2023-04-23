using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int HPMax = 100;
    private int HP;

    private void Awake()
    {
        HP = HPMax;
    }

    public float GetHPPercent()
    {
        return (float)HP / HPMax;
    }

    public int GetHP()
    {
        return HP;
    }

    public bool IsDead()
    {
        return (HP <= 0);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
