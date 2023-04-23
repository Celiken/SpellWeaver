using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public static Player Instance;

    private const string TOOK_DAMAGE_UI = "TookDamage";

    [SerializeField] private float dashSpeed;
    [SerializeField] private Transform spellCastPoint;
    [SerializeField] private Transform spellAuraPoint;

    [SerializeField] private Animator UIAnimator;
    [SerializeField] private TextMeshProUGUI damageUI;

    private CharacterController characterController;
    private NavMeshAgent agent;
    private HealthComponent healthComponent;

    private bool isWalking;

    private Vector3 dashDirection;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashMaxTimer = 0.1f;

    private float dashCooldownMax = 5f;
    private float dashCooldown;
    private int MP = 345;
    private int MPMax = 1000;

    private void Awake()
    {
        Instance = this;
        healthComponent = GetComponent<HealthComponent>();
        agent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        damageUI.gameObject.SetActive(false);
        GameInput.Instance.OnDash += GameInput_OnDash;
        GameInput.Instance.OnAim += GameInput_OnAim;
    }

    void Update()
    {
        if (dashCooldown > 0f) dashCooldown -= Time.deltaTime;
        if (isDashing)
        {
            Dash();
            dashTimer += Time.deltaTime;
            if (dashTimer > dashMaxTimer)
            {
                dashTimer = 0f;
                isDashing = false;
                agent.ResetPath();
            }
        }
        else
            Move();

    }

    private void Move()
    {
        if (GameInput.Instance.GetMoveInput() == 1f)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << LayerConstants.GROUND))
            {
                if (hit.collider.CompareTag(TagConstants.GROUND))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    private void GameInput_OnDash(object sender, System.EventArgs e)
    {
        if (dashCooldown <= 0f)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << LayerConstants.GROUND))
            {
                if (hit.collider.CompareTag(TagConstants.GROUND))
                {
                    dashDirection = (hit.point - transform.position).normalized;
                    isDashing = true;
                    dashTimer = 0f;
                    dashCooldown = dashCooldownMax;
                }
            }
        }
    }

    private void GameInput_OnAim(object sender, System.EventArgs e)
    {
        Aim();
    }

    public void Aim()
    {
        agent.ResetPath();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << LayerConstants.GROUND))
        {
            if (hit.collider.CompareTag(TagConstants.GROUND))
            {
                Vector3 lookDirection = (hit.point - transform.position).normalized;
                transform.forward = lookDirection;
            }
        }
    }

    private void Dash()
    {
        float dashDistance = dashSpeed * Time.deltaTime;
        characterController.Move(dashDirection * dashDistance);

        isWalking = dashDirection != Vector3.zero;

        transform.forward = dashDirection;
    }

    public void GetHit(int damage)
    {
        healthComponent.TakeDamage(damage);
        damageUI.text = damage.ToString();
        damageUI.gameObject.SetActive(true);
        UIAnimator.SetTrigger(TOOK_DAMAGE_UI);
    }

    public float GetHPPercent()
    {
        return healthComponent.GetHPPercent();
    }

    public float GetMPPercent()
    {
        return (float)MP / MPMax;
    }
    public float GetDashCDPercent()
    {
        return dashCooldown / dashCooldownMax;
    }

    public Transform GetCastPoint()
    {
        return spellCastPoint;
    }
    public Transform GetAuraPoint()
    {
        return spellAuraPoint;
    }
}
