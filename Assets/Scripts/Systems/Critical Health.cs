using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CriticalHealth : MonoBehaviour
{
    private bool isCritical = false;

    public TMPro.TextMeshProUGUI healthText; // Reference to the health text

    public Player player; // Reference to the player
    public Item item; // Reference to the item script

    public SpriteRenderer Overlay; // the overlay for the critical and ice effects
    private void Start()
    {
        player.onTakeDamage.AddListener(CheckHealth);// Add listener for damage
        player.onHeal.AddListener(CheckHealth); // Add listener for healing
    }

    void CheckHealth()
    {
        if (player.health <= 40)
        {
            healthText.text = "Critical Health!"; // Update health text
            isCritical = true;
            player.onTakeDamage.AddListener(ShowRedScreenEffect); // Add new effect
        }
        else
        {
            healthText.text = ""; // Clear health text
            isCritical = false;
            player.onTakeDamage.RemoveListener(ShowRedScreenEffect); // Remove effect
        }
    }

    void ShowRedScreenEffect()
    {
        if (player.health > 0)
        {
            isCritical = true; // if the player's health isnt 0 but below 40 the player's health is critical
        }
        else
        {
            healthText.text = ""; // Clear health text
            isCritical = false; // the player's health is not critical
            player.onTakeDamage.RemoveListener(ShowRedScreenEffect); // Remove effect
        }
    }

    void FixedUpdate()
    {
        if (isCritical)
        {
            //display the critical health overlay
            Overlay.color = new Color(1, 0, 0, (Mathf.PingPong(Time.time, 0.5f))); // red overlay
        }
        else if (player.isOnIce)
        {
            //displays the ice overlay
            Overlay.color = new Color(0, 0, 1, (Mathf.PingPong(Time.time, 0.5f))); // blue overlay
        }
        else if (isCritical && player.isOnIce)
        {
            //displays the ice and critical health overlay
            Overlay.color = new Color(1, 0, 1, (Mathf.PingPong(Time.time, 0.5f))); // purple overlay
        }
        else
        {
            //resets the overlay
            Overlay.color = new Color(0, 0, 0, 0); // Reset to transparent
        }
    }
}
