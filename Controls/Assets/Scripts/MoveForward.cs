using System.Collections;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f;
    private readonly float _destroyTime = 20f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DeleteObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.forward);
    }

    IEnumerator DeleteObject()
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
