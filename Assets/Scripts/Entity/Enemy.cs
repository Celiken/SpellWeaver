using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private const string TOOK_DAMAGE_UI = "TookDamage";

    private NavMeshAgent agent;
    private Player player;
    private HealthComponent healthComponent;

    [SerializeField] private Image HPBar;
    [SerializeField] private float rangeAttack;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;

    [SerializeField] private Transform damagePopupPosition;

    private float nextAttackTimer;
    private float startAttacking;
    private float delayBeforeFirstHit = 2f;
    private bool isMelee;

    private void Awake()
    {
        isMelee = false;
        nextAttackTimer = 0f;
        agent = GetComponent<NavMeshAgent>();
        healthComponent = GetComponent<HealthComponent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        UpdateHPBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (!healthComponent.IsDead())
        {
            if (nextAttackTimer > 0f) nextAttackTimer -= Time.deltaTime;
            agent.destination = player.transform.position;
            if ((transform.position - player.transform.position).magnitude <= rangeAttack)
            {
                Vector3 lookDirection = (player.transform.position - transform.position).normalized;
                transform.forward = lookDirection;
                if (isMelee)
                {
                    startAttacking -= Time.deltaTime;
                    if (nextAttackTimer <= 0f && startAttacking <= 0f)
                    {
                        player.GetHit(damage);
                        nextAttackTimer = attackCooldown;
                    }
                } else
                {
                    isMelee = true;
                    startAttacking = delayBeforeFirstHit;
                }
            } else
            {
                isMelee = false;
            }
        }
    }

    public void GetHit(int damage)
    {
        healthComponent.TakeDamage(damage);
        DamagePopup.Create(damagePopupPosition.position, damage, DamagePopup.Font.DamageDeal);
        UpdateHPBar();
        if (healthComponent.IsDead())
        {
            agent.ResetPath();
            Destroy(gameObject, 0.5f);
        }
    }

    private void UpdateHPBar()
    {
        HPBar.fillAmount = healthComponent.GetHPPercent();
    }
}
