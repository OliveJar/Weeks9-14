using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eventsdemo : MonoBehaviour
{
    public RectTransform star;
    public Image Clr;
    public Slider T;

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
        Clr.color = Color.yellow;
    }
    public void Changec()
    {
        Clr.color = Color.Lerp(Color.red, Color.blue, T.value);
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
