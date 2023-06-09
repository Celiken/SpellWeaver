using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform spellCastPoint;
    [SerializeField] private Transform spellAuraPoint;

    [SerializeField] private Transform damagePopupPosition;

    [SerializeField] private LayerMask layerMoveRaycast;

    private CharacterController characterController;
    private NavMeshAgent agent;

    private DashComponent dashComponent;
    private HealthComponent healthComponent;
    private ManaComponent manaComponent;

    private bool isWalking;

    private Vector3 dashDirection;
    private Vector3 lookDirection;

    private void Awake()
    {
        Instance = this;
        dashComponent = GetComponent<DashComponent>();
        manaComponent = GetComponent<ManaComponent>();
        healthComponent = GetComponent<HealthComponent>();
        agent = GetComponent<NavMeshAgent>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!dashComponent.IsDashing())
        {
            Move();
            Aim();
        }
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public Vector3 GetDashDirection()
    {
        return dashDirection;
    }

    public void SetDashDirection(Vector3 dashDirection)
    {
        this.dashDirection = dashDirection;
    }

    public Vector3 GetLookDirection()
    {
        return lookDirection;
    }

    private void Move()
    {
        Vector2 inputVector = GameInput.Instance.GetMoveInput();

        Vector3 moveDir = new(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance, layerMoveRaycast);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > .5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance, layerMoveRaycast);
            if (canMove)
                moveDir = moveDirX;
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > .5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance, layerMoveRaycast);
                if (canMove)
                    moveDir = moveDirZ;
            }
        }
        if (canMove)
            transform.position += moveDir * moveDistance;

        dashDirection = moveDir;
        isWalking = moveDir != Vector3.zero;
    }

    public void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << LayerConstants.GROUND))
        {
            if (hit.collider.CompareTag(TagConstants.GROUND))
            {
                lookDirection = (hit.point - transform.position).normalized;
                transform.forward = Vector3.Slerp(transform.forward, lookDirection, Time.deltaTime * rotateSpeed);
            }
        }
    }

    public void GetHit(int damage)
    {
        healthComponent.TakeDamage(damage);
        DamagePopup.Create(damagePopupPosition.position, -1 * damage, DamagePopup.Font.DamageTaken);
    }

    public float GetHPPercent()
    {
        return healthComponent.GetHPPercent();
    }

    public float GetMPPercent()
    {
        return manaComponent.GetMPPercent();
    }
    public void UseMana(float manaCost)
    {
        manaComponent.UseMana(manaCost);
    }
    public bool HasEnoughMana(float manaCost)
    {
        return manaComponent.HasEnoughMana(manaCost);
    }

    public float GetDashCDPercent()
    {
        return dashComponent.GetDashCD();
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
