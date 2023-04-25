using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DashComponent : MonoBehaviour
{
    public enum DashState
    {
        NOT_DASHING,
        PRE_DASH,
        DASH,
        POST_DASH,
    }

    [SerializeField] private float dashSpeed;
    [SerializeField] private float prepostDashingTimer = .2f;
    [SerializeField] private float dashCooldownMax = 5f;

    [SerializeField] private Material bodyMat, eyesMat;

    private DashState dashState;
    private Player player;
    private NavMeshAgent agent;

    private float dashTimer = 0f;
    private float dashCooldown;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GetComponent<Player>();

    }

    private void Start()
    {
        GameInput.Instance.OnDash += GameInput_OnDash;
    }

    private void Update()
    {
        if (dashCooldown > 0f) dashCooldown -= Time.deltaTime;
        if (dashState != DashState.NOT_DASHING)
        {
            dashTimer += Time.deltaTime;
            switch (dashState)
            {
                case DashState.NOT_DASHING:
                    break;
                case DashState.PRE_DASH:
                    bodyMat.SetFloat("_Dissolve", dashTimer / prepostDashingTimer);
                    eyesMat.SetFloat("_Dissolve", dashTimer / prepostDashingTimer);
                    if (dashTimer > prepostDashingTimer)
                    {
                        dashState = DashState.DASH;
                        dashTimer = 0f;
                    }
                    break;
                case DashState.DASH:
                    Dash();
                    dashState = DashState.POST_DASH;
                    break;
                case DashState.POST_DASH:
                    bodyMat.SetFloat("_Dissolve", (prepostDashingTimer - dashTimer) / prepostDashingTimer);
                    eyesMat.SetFloat("_Dissolve", (prepostDashingTimer - dashTimer) / prepostDashingTimer);
                    if (dashTimer > prepostDashingTimer)
                    {
                        dashState = DashState.NOT_DASHING;
                        dashTimer = 0f;
                    }
                    break;
            }
        }
    }


    private void OnDestroy()
    {
        GameInput.Instance.OnDash -= GameInput_OnDash;
    }


    private void GameInput_OnDash(object sender, System.EventArgs e)
    {
        if (!player.IsWalking())
        {
            player.SetDashDirection(player.GetLookDirection());
        }
        if (dashCooldown <= 0f && GameManager.Instance.IsGameStarted())
        {
            agent.ResetPath();
            dashState = DashState.PRE_DASH;
            dashTimer = 0f;
            dashCooldown = dashCooldownMax;
        }
    }

    private void Dash()
    {
        if (player.IsWalking())
        {
            transform.position += player.GetDashDirection() * dashSpeed;
        }
        else
        {
            transform.position += player.GetLookDirection() * dashSpeed;
        }
    }

    public bool IsDashing()
    {
        return dashState != DashState.NOT_DASHING;
    }

    public float GetDashCD()
    {
        return dashCooldown / dashCooldownMax;
    }
}
