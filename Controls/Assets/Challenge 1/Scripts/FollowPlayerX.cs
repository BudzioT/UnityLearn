using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset = new Vector3(30, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float cameraX = plane.transform.position.x + offset.x;
        float cameraY = plane.transform.position.y + offset.y;
        float cameraZ = plane.transform.position.z + offset.z;
        transform.position = new Vector3(cameraX, cameraY, cameraZ);
    }
}
