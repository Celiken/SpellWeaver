using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SpellUI : MonoBehaviour
{
    [SerializeField] private SpellSO spellSO;

    [SerializeField] private Image spellIcon;
    [SerializeField] private Image cooldownImage;
    [SerializeField] private TextMeshProUGUI spellCooldownText;
    [SerializeField] private TextMeshProUGUI spellKeyText;

    [SerializeField] private Transform cooldownUI;

    private Player player;

    private InputAction spellTrigger;

    private bool available = true;
    private float cooldownTimer = 0f;

    private bool guideBlocker;

    private void Awake()
    {
        guideBlocker = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
        HideCooldownUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (guideBlocker) guideBlocker = !GameManager.Instance.IsGameStarted();
        if (!available)
        {
            cooldownTimer -= Time.deltaTime;
            UpdateCooldownUI();
            if (cooldownTimer <= 0f)
            {
                available = true;
                HideCooldownUI();
            }
        }
    }

    private void OnDestroy()
    {
        spellTrigger.performed -= SpellTrigger_performed;
    }

    public void SetSpell(SpellSO spellSo, int spellSlot)
    {
        spellSO = spellSo;
        spellIcon.sprite = spellSo.spellIcon;
        spellTrigger = GameInput.Instance.GetInputActionForSpell(spellSlot);
        spellKeyText.text = spellTrigger.bindings[0].ToDisplayString();
        spellTrigger.performed += SpellTrigger_performed;

    }

    private void SpellTrigger_performed(InputAction.CallbackContext obj)
    {
        UseSpell();
    }

    private void UseSpell()
    {
        if (!guideBlocker && available && player.HasEnoughMana(spellSO.spellMana))
        {
            cooldownTimer = spellSO.spellCooldown;
            available = false;
            player.UseMana(spellSO.spellMana);
            ShowCooldownUI();
            GameObject spellObj;
            if (spellSO.spellType == SpellSO.SpellType.Projectile)
            {
                spellObj = Instantiate(spellSO.spellPrefab, player.GetCastPoint().position, player.GetCastPoint().rotation);
                spellObj?.GetComponent<ProjectileSpell>().SetSpellSO(spellSO as ProjectileSpellSO);
            }
            else if (spellSO.spellType == SpellSO.SpellType.AOE)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << LayerConstants.GROUND))
                {
                    if (hit.collider.CompareTag(TagConstants.GROUND))
                    {
                        spellObj = Instantiate(spellSO.spellPrefab, hit.point, Quaternion.identity);
                        spellObj?.GetComponent<AOESpell>().SetSpellSO(spellSO as AOESpellSO);
                    }
                }
            }
            else if (spellSO.spellType == SpellSO.SpellType.PlayerCenteredAOE)
            {
                spellObj = Instantiate(spellSO.spellPrefab, player.transform.position, Quaternion.identity);
                spellObj?.GetComponent<AOESpell>().SetSpellSO(spellSO as AOESpellSO);
            }
        }
    }

    private void ShowCooldownUI()
    {
        cooldownUI.gameObject.SetActive(true);
        UpdateCooldownUI();
    }

    private void UpdateCooldownUI()
    {
        spellCooldownText.text = Mathf.Ceil(cooldownTimer).ToString();
        cooldownImage.fillAmount = cooldownTimer / spellSO.spellCooldown;
    }

    private void HideCooldownUI()
    {
        cooldownUI.gameObject.SetActive(false);
    }
}
