using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_StatSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private UI ui;

    [SerializeField] private string statName;
    [SerializeField] private StatType statType;
    [SerializeField] private TextMeshProUGUI statValveText;
    [SerializeField] private TextMeshProUGUI statNameText;

    [TextArea]
    [SerializeField] private string statDescription;


    private void OnValidate()
    {
        gameObject.name = "Stat - " + statName;

        if (statValveText != null )
            statNameText.text = statName;
    }
    void Start()
    {
        UpdateStatValueUI();

        ui = GetComponentInParent<UI>();
    }

    // Update is called once per frame

    public void UpdateStatValueUI()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            statValveText.text = playerStats.GetStat(statType).GetValue().ToString();

            if(statType == StatType.health)
                statValveText.text = playerStats.GetMaxHealthValue().ToString();

            if(statType == StatType.damage)
                statValveText.text = (playerStats.damage.GetValue() + playerStats.strength.GetValue()).ToString();

            if(statType == StatType.critPower)
                statValveText.text = (playerStats.critPower.GetValue() + playerStats.strength.GetValue()).ToString();

            if(statType == StatType.critChance)
                statValveText.text = (playerStats.critChance.GetValue() + playerStats.agility.GetValue()).ToString();

            if (statType == StatType.evasion)
                statValveText.text = (playerStats.evasion.GetValue() + playerStats.agility.GetValue()).ToString();

            if (statType == StatType.magicRes)
                statValveText.text = (playerStats.magicResistance.GetValue() + (playerStats.intelligence.GetValue() * 3)).ToString();



        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ui.statToolTip.ShowStatToolTip(statDescription);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ui.statToolTip.HideStatToolTip();
    }
}
