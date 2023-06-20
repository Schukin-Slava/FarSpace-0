using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageAble : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;

    public UnityEvent<int, int> healthChanged;

    public UnityEvent<int, int> amunitionChanged;
    Animator animator;

    [SerializeField]
    private int _maxAmunition =50;

    public int MaxAmunition
    {
        get
        {
            return _maxAmunition;
        }
        set
        {
            _maxAmunition = value;
        }
    }

    [SerializeField]
    private int _amunition = 50;
    public int Amunition
    {
        get
        {
            return _amunition;
        }
        set
        {

            _amunition = value;
            amunitionChanged?.Invoke(_amunition, MaxAmunition);
            if(_amunition <= 0 ) 
            {
                animator.SetBool(AnimationStrings.isAmunition, false);
            }
        }
    }

    [SerializeField]
    private int _maxHealth = 100;
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {

            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool isInvincible =false;



    private float timerSinceHit = 0;
    public float invincibilityTimer = 0.25f;

    private bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        { 
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("is Alive set " + value);
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (isInvincible)
        {
            if(timerSinceHit > invincibilityTimer)
            {
                isInvincible=false;
                timerSinceHit = 0;
            }
            timerSinceHit += Time.deltaTime;
        }
    }
    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    public bool Hit(int damage, Vector2 knockBack)
    {
        if(IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
            
            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damageableHit?.Invoke(damage, knockBack);

            CharacterEvent.characterDamaged.Invoke(gameObject, damage);

            return true;
        }
        return false;
    }

    public bool Heal(int healthHealing)
    {
        if (IsAlive && Health < MaxHealth )
        {
            int maxHealth = Mathf.Max(MaxHealth-Health, 0);
            int actualHeal = Mathf.Min(maxHealth, healthHealing);
            Health += actualHeal;
            CharacterEvent.characterHealed.Invoke(gameObject, actualHeal);
            return true;
        }
        return false;
    }

    internal bool GetBullett(int amunitionGet)
    {
        if (IsAlive && Amunition < MaxAmunition)
        {
            int maxAmunition = Mathf.Max(MaxAmunition - Amunition, 0);
            int actualAmunition = Mathf.Min(maxAmunition, amunitionGet);
            Amunition += actualAmunition;
            CharacterEvent.characterAmunition.Invoke(gameObject, actualAmunition);
            return true;
        }
        return false;
    }
}
