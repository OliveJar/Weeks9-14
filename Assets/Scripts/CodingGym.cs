using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodingGym : MonoBehaviour
{
    public RectTransform Planet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void entered()
    {
        Debug.Log("entered");
        Planet.localScale = new Vector2(1.3f ,1.3f);
    }
    public void left()
    {
        Debug.Log("entered");
        Planet.localScale = new Vector2(1, 1);
    }
    public void random()
    {
        Debug.Log("entered");
        Planet.anchoredPosition = new Vector2(Random.Range(-500, 500), Random.Range(-280, 280));
    }
}
