using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public int multiplier;
    public float HeightAxis;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        if (Input.GetKey("up"))
        {
            HeightAxis = 0.05f;
        }

        if (Input.GetKey("down"))
        {
            HeightAxis = -0.05f;
        }

        Vector3 moveDirection = new Vector3((xDirection * 0.005f * multiplier), (HeightAxis * 0.1f * multiplier), (yDirection * 0.005f * multiplier));

        transform.position += moveDirection;

        HeightAxis = 0.0f;
    }
}
