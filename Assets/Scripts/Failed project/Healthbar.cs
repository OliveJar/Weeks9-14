using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Player player; // Reference to the player
    public RectTransform healthbar;

    private void Start()
    {
        player.onTakeDamage.AddListener(UpdateHealthBar);
    }

    public void UpdateHealthBar()
    {
        healthbar.localScale = new Vector3(player.health * 3, healthbar.localScale.y, healthbar.localScale.z);
    }
}
