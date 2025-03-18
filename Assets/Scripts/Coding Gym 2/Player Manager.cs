using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool Switched;
    [SerializeField]
    private PlayerMovement player1;
    [SerializeField]
    private PlayerMovement player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Switched)
        {
            StartCoroutine(switchplayer2());
        }
        if (!Switched)
        {
            StartCoroutine(switchplayer1());
        }
    }



    private IEnumerator switchplayer1()
    {
        player2.enabled = false;
        player1.enabled = true;
        yield return new WaitForSeconds(10);
        Switched = true;
    }
    private IEnumerator switchplayer2()
    {
        player1.enabled = false;
        player2.enabled = true;
        yield return new WaitForSeconds(10);
        Switched = false;
    }
}
