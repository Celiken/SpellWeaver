using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private Image HPBar;
    [SerializeField] private Image MPBar;
    [SerializeField] private Image DashCooldown;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.fillAmount = player.GetHPPercent();
        MPBar.fillAmount = player.GetMPPercent();
        DashCooldown.fillAmount = player.GetDashCDPercent();
    }
}
