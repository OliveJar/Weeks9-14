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
    public UnityEvent onDeath; // Event for death
    public UnityEvent onRadiation; // Event for item pickup
    public UnityEvent onFire; // Event for fire effect

    public float health = 100;

    [HideInInspector]
    public Item item; // Reference to the item script

    private bool isTakingDamage = false; // if the player is taking damage set to no

    [HideInInspector]
    public bool isOnIce = false; // Variable to track if the player is iced

    [SerializeField]
    private float duration = 5f; // Duration for damage over time

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= (damage); // if the health isnt 0 take damage by the damage amount
        }

        onTakeDamage?.Invoke(); // Trigger event after damage is taken

        if (health <= 0)
        {
            onDeath?.Invoke(); // Trigger death event
            health = 0; // Ensure health doesn't go below 0
        }
    }

    public void Fire()
    {
        onFire?.Invoke(); // Trigger fire effect event
    }

    public void Ice()
    {
        onIce?.Invoke(); // Trigger ice effect event
        isOnIce = true; // the player is on ice
    }

    public void Heal(float healAmount)
    {
        if (health < 100)
        {
            health += healAmount; // heal by the heal amount if the health isnt full
            onHeal?.Invoke(); // Trigger event after damage is taken
        }
    }

    public void TakeDamageOverTime(int damage)
    {
        if (!isTakingDamage)
            StartCoroutine(DamageOverTimeCoroutine(damage, duration)); // start taking damage over time
    }

    public IEnumerator DamageOverTimeCoroutine(int damage, float time)
    {
        onRadiation?.Invoke(); // Trigger radiation event

        float elapsed = 0f; // reset timer

        while (elapsed < time) // while the elapsed time is under the damage time
        {
            TakeDamage((damage * 0.025f) / time); // Take damage every incriment of time
            elapsed += Time.deltaTime * 1.0f; // Increment elapsed time
            onTakeDamage?.Invoke(); // Trigger event after damage is taken
            isTakingDamage = true; // Set taking damage state
            yield return null;
        }
        isOnIce = false; // Reset ice effect
        isTakingDamage = false; // Reset taking damage state
    }
}
