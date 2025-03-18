using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    [SerializeField]
    private Transform minuteHand;

    [SerializeField]
    private Transform hourHand;

    public UnityEvent OnTheHour;

    void Start()
    {
        StartCoroutine(runTheClock());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(runTheClock());
        }
    }

    private IEnumerator runTheClock()
    {
            yield return StartCoroutine(time());
    }

    private IEnumerator time ()
    {
        t = 0;

        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(360 / (timeAnHourTakes * 12)) * Time.deltaTime);

            yield return null;
        }
        OnTheHour.Invoke();
    }

}
