using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent onTakeDamage; // Event for taking damage
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Player took {damage} damage! Health: {health}");

        onTakeDamage?.Invoke(); // Trigger event after damage is taken
    }
}
