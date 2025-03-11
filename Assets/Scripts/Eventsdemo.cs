using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventsdemo : MonoBehaviour
{
    public RectTransform star;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pushedbutton()
    {
        Debug.Log("Button pushed");
    }
    public void Alsopushedbutton()
    {
        Debug.Log("Me too");
    }
    public void entered()
    {
        Debug.Log("entered");
        star.localScale = new Vector2(1,1);
    }
    public void left()
    {
        Debug.Log("entered");
        star.localScale = new Vector2(0.5f, 0.5f);
    }
    public void random()
    {
        Debug.Log("entered");
        star.anchoredPosition = new Vector2(Random.Range(-500, 500), Random.Range(-280, 280));
    }
}
