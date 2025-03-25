using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private Vector3 direction;

    public PlayerMovement PMScript;

    [SerializeField]
    private Rigidbody2D Rb;

    [SerializeField]
    private GameObject body;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        if (Input.GetButton("Fire1"))
        {
            PMScript.enabled = false;

            direction = mouse - body.transform.position;
            transform.up = direction / 2;
            transform.position = body.transform.position;
            transform.localScale = new Vector2(0.65f, direction.magnitude);

            Rb.velocity = (mouse - transform.position).normalized * 10;
        }
        else
            transform.localScale = new Vector2(0.65f, 0.1f);

        if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(wait());
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        PMScript.enabled = true;
    }
}
