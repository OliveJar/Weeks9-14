using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Player player; // Reference to the player
    public RectTransform healthbar; // Reference to the healthbar

    private void Start()
    {
        player.onTakeDamage.AddListener(UpdateHealthBar); // Add listener for damage
        player.onHeal.AddListener(UpdateHealthBar); // Add listener for heal
    }

    public void UpdateHealthBar()
    {
        //Updates the healthbar anytime the player takes damage or heals
        healthbar.localScale = new Vector3(player.health * 3, healthbar.localScale.y, healthbar.localScale.z);
    }
}
