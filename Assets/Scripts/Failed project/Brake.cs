using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    public Playermovement playermovement; // Reference to the playermovement
    public RectTransform brakeBar;

    // Update is called once per frame
    void Update()
    {
         brakeBar.localScale = new Vector2(Mathf.Min(playermovement.t * 3000, 300), brakeBar.localScale.y);
    }
}
