using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBarSlider;
    public TMP_Text healthBarText;
    DamageAble playerDamageAble;

    // Start is called before the first frame update
    void Start()
    {

        healthBarSlider.value = CalculateSlider(playerDamageAble.Health, playerDamageAble.MaxHealth);
        healthBarText.text = "Health " + playerDamageAble.Health + "/" + playerDamageAble.MaxHealth;
    }
    public void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null )
        {
            Debug.Log("no PLAYER");
        }
        playerDamageAble = player.GetComponent<DamageAble>();
    }
    private float CalculateSlider(float healthNow, float maxHealth)
    {
        return healthNow / maxHealth;
    }
    public void OnEnable()
    {
        playerDamageAble.healthChanged.AddListener(OnPlayerHealthChanged);
    }
    public void OnDisable()
    {
        playerDamageAble.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }
    // Update is called once per frame
    public void OnPlayerHealthChanged(int newHealth,int maxHealth)
    {
        healthBarSlider.value = CalculateSlider(newHealth, maxHealth);
        healthBarText.text = "Health " + newHealth + "/" + maxHealth;
    }  
}
