using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent onTakeDamage; // Event for taking damage
    public UnityEvent onIce; // Event for ice effect
    public UnityEvent onHeal; // Event for healing
    public float health = 100;

    private bool isTakingDamage = false;
    [HideInInspector]
    public bool isOnIce = false; // Variable to track if the player is iced

    [SerializeField]
    private float duration = 5f; // Duration for damage over time

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= (damage);
        }

        onTakeDamage?.Invoke(); // Trigger event after damage is taken
    }

    public void Ice()
    {
        onIce?.Invoke(); // Trigger ice effect event
        isOnIce = true;
    }

    public void Heal(float healAmount)
    {
        if (health < 100)
        {
            health += healAmount;
            onHeal?.Invoke(); // Trigger event after damage is taken
        }
    }

    public void TakeDamageOverTime(int damage)
    {
        if (!isTakingDamage)
            StartCoroutine(DamageOverTimeCoroutine(damage, duration));
    }

    public IEnumerator DamageOverTimeCoroutine(int damage, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            TakeDamage((damage * 0.025f) / time);
            elapsed += Time.deltaTime * 1.0f;
            onTakeDamage?.Invoke(); // Trigger event after damage is taken
            isTakingDamage = true;
            yield return null;
        }
        isOnIce = false; // Reset ice effect
        isTakingDamage = false;
    }
}
