using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text itemNameText; // Reference to the item pickup text
    [SerializeField] private TMPro.TMP_Text IceText; // Reference to the item count text
    [SerializeField] private TMPro.TMP_Text RadsText; // Reference to the item count text
    [SerializeField] private TMPro.TMP_Text FireText; // Reference to the item count text

    //Item and health Game Objects
    public GameObject fireObj;
    public GameObject iceObj;
    public GameObject radiation;
    public GameObject health;
    public GameObject healthBar;

    [SerializeField] private bool isDone = false; // Is the game done

    public Player player; // Reference to the player

    public UnityEvent isDed; // Event for death

    private int rads = 0; //radiation Knowledge value
    private int fire = 0; //fire Knowledge value
    private int ice = 0; //ice Knowledge value
    
    // Start is called before the first frame update
    void Start()
    {
        player.onIce.AddListener(IceItem); // Add listener for ice pickup
        player.onFire.AddListener(FireItem); // Add listener for fire pickup
        player.onRadiation.AddListener(RadiationItem); // Add listener for radiation pickup
        player.onDeath.AddListener(onDeath); // Add listener for death event
    }

    //if Ice button is clicked
    void IceItem()
    {
        itemNameText.text = "You found Aluminum Sheets";
        ice++;
        StartCoroutine(wait2());
    }

    //if Radiation button is clicked
    void RadiationItem()
    {
        itemNameText.text = "You found Lead Plating";
        rads++;
        StartCoroutine(wait2());
    }
    //if Fire button is clicked
    void FireItem()
    {
        itemNameText.text = "You found AeroGel sheets";
        fire++;
        StartCoroutine(wait2());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if the ice knowledge is greater than 20, remove the listener
        if (ice >= 20)
        {
            player.onIce.RemoveListener(IceItem);
            IceText.text = "Congrats you now no longer take damage from ice"; // Update the text with the current count
            iceObj.SetActive(false);
        }
        else
            IceText.text = "Ice knowledge: " + ice.ToString(); // Update the text with the current count

        //if the radiation knowledge is greater than 20, remove the listener
        if (rads >= 20)
        {
            player.onRadiation.RemoveListener(RadiationItem);
            RadsText.text = "Congrats you now no longer take damage from radiation"; // Update the text with the current count
            radiation.SetActive(false);
        }
        else
            RadsText.text = "Radiation knowledge: " + rads.ToString(); // Update the text with the current count

        //if the fire knowledge is greater than 20, remove the listener
        if (fire >= 20)
        {
            player.onFire.RemoveListener(FireItem);
            FireText.text = "Congrats you now no longer take damage from fire"; // Update the text with the current count
            fireObj.SetActive(false);
        }
        else
            FireText.text = "Fire knowledge: " + fire.ToString(); // Update the text with the current count

        //if the player has all 3 items with 20 knowledge, remove the listeners
        if (ice >= 20 && fire >= 20 && rads >= 20)
        {
            itemNameText.text = "Congrats! You no longer need to worry about the hazards and can finaly go home.";

            //clears the items' text
            IceText.text = "";
            RadsText.text = "";
            FireText.text = "";

            // Remove listeners for all items
            player.onIce.RemoveListener(IceItem);
            player.onFire.RemoveListener(FireItem);
            player.onRadiation.RemoveListener(RadiationItem);
            health.SetActive(false); //disablt the heal button
            healthBar.SetActive(false); // Disable the health bar

            //Wait to end the game
            StartCoroutine(wait());
        }

        if (isDone)
        {
            // Set the game text to game over

            itemNameText.text = "Game Over";

            //clears the items' text
            IceText.text = "";
            RadsText.text = "";
            FireText.text = "";

            //if the game is done, remove the listeners
            player.onIce.RemoveListener(IceItem);
            player.onFire.RemoveListener(FireItem);
            player.onRadiation.RemoveListener(RadiationItem);

            health.SetActive(false); //disablt the heal button
            healthBar.SetActive(false); // Disable the health bar
            fireObj.SetActive(false); // Disable the fire object
            iceObj.SetActive(false); // Disable the ice object
            radiation.SetActive(false); // Disable the radiation object
        }
    }

    private void onDeath()
    {
        isDone = true; // Set the game as done
    }
    private IEnumerator wait2()
    {
        // Wait for 2 seconds before clearing the text
        yield return new WaitForSeconds(2);
        itemNameText.text = "";
    }

    private IEnumerator wait()
    {
        // Wait for 5 seconds before ending the game
        yield return new WaitForSeconds(5);
        isDone = true;
    }
}
