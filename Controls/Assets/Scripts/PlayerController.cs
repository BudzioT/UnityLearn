using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 30f;
    private float horizontalInput;
    private float forwardInput;
    public int playerIndex = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (playerIndex == 0)
        {
            forwardInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else if (playerIndex == 1)
        {
            forwardInput = Input.GetAxis("Vertical2");
            horizontalInput = Input.GetAxis("Horizontal2");
        }
        
        transform.Translate(Time.deltaTime * speed * forwardInput * Vector3.forward);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
