using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(horizontalInput * rotationSpeed * Time.deltaTime * Vector3.up);
    }
}
