using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHealth : MonoBehaviour
{
    private bool isCritical = false;

    public Player player; // Reference to the player

    public SpriteRenderer redOverlay;
    private void Start()
    {
        player.onTakeDamage.AddListener(CheckHealth);
    }

    void CheckHealth()
    {
        if (player.health <= 40)
        {
            Debug.Log("CRITICAL WARNING: Health is low!");
            isCritical = true;
            player.onTakeDamage.AddListener(ShowRedScreenEffect); // Add new effect
        }
        else
        {
            player.onTakeDamage.RemoveListener(ShowRedScreenEffect); // Remove effect
        }
    }

    void ShowRedScreenEffect()
    {
        isCritical = true;
    }

    void Update()
    {
        if (isCritical)
        {
            redOverlay.color = new Color(1, 0, 0, (Mathf.PingPong(Time.time, 50)));
        }

        if (player.health <= 0)
        {
            //Debug.Log("Player is dead!");
        }
    }
}
