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

    [SerializeField] private Animator UIAnimator;
    [SerializeField] private TextMeshProUGUI damageUI;

    private float nextAttackTimer;

    private void Awake()
    {
        nextAttackTimer = 0f;
        agent = GetComponent<NavMeshAgent>();
        healthComponent = GetComponent<HealthComponent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        damageUI.gameObject.SetActive(false);
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
            if ((transform.position - player.transform.position).magnitude <= rangeAttack && nextAttackTimer <= 0f)
            {
                player.GetHit(damage);
                nextAttackTimer = attackCooldown;
            }
        }
    }

    public void GetHit(int damage)
    {
        healthComponent.TakeDamage(damage);
        damageUI.text = damage.ToString();
        damageUI.gameObject.SetActive(true);
        UIAnimator.SetTrigger(TOOK_DAMAGE_UI);
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
