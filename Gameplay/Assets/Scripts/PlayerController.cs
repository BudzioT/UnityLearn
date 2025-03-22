using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontalInput;
    private float _verticalInput;
    private readonly float _speed = 10f;
    private readonly float _rangeX = 18f;
    private readonly float _rangeTop = 17f;
    private readonly float _rangeBottom = -2f;
    public GameObject projectile;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(_speed * _horizontalInput * Time.deltaTime * Vector3.right);
        if (transform.position.x < -_rangeX)
        {
            transform.position = new Vector3(-_rangeX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > _rangeX)
        {
            transform.position = new Vector3(_rangeX, transform.position.y, transform.position.z);
        }
        
        transform.Translate(_speed * _verticalInput * Time.deltaTime * Vector3.forward);
        if (transform.position.z < _rangeBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _rangeBottom);
        }
        else if (transform.position.z > _rangeTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _rangeTop);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
