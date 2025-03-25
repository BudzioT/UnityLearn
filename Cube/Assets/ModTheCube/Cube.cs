using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 location;
    public Vector3 scale;
    public float angle;
    public float rotationSpeed;
    public Color materialColor;
    
    void Start()
    {
        transform.position = location;
        transform.localScale = scale;
        
        Material material = Renderer.material;
        
        material.color = materialColor;
    }
    
    void Update()
    {
        transform.Rotate(Vector3.right, angle * rotationSpeed * Time.deltaTime);
    }
}
