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
        player.onIce.AddListener(showBlueScreenEffect);
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
            isCritical = false; // Reset the effect
        }
    }

    void ShowRedScreenEffect()
    {
        isCritical = true;
    }
    void showBlueScreenEffect()
    {
        
    }

    void Update()
    {
        if (isCritical)
        {
            redOverlay.color = new Color(1, 0, 0, (Mathf.PingPong(Time.time, 0.5f)) );
        }
        else if (player.isOnIce)
        {
            redOverlay.color = new Color(0, 0, 1, (Mathf.PingPong(Time.time, 0.5f)));
        }
        else if (isCritical && player.isOnIce)
        {
            redOverlay.color = new Color(1, 0, 1, (Mathf.PingPong(Time.time, 0.5f)));
        }
        else
        {
            redOverlay.color = new Color(0, 0, 0, 0); // Reset to transparent
        }

        if (player.health <= 0)
        {
            //Debug.Log("Player is dead!");
        }
    }
}
