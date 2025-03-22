using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 0.5f;
    private float rotationSpeed = 150;
    public float verticalInput;
    public int playerIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerIndex == 0)
        {
            verticalInput = Input.GetAxis("Vertical");
        }
        else if (playerIndex == 1)
        {
            verticalInput = Input.GetAxis("Vertical");
        }

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(rotationSpeed * Time.deltaTime * verticalInput * Vector3.right);
    }
}
