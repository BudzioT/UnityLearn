using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 thirdViewOffset = new (0, 5, -10);
    public Vector3 firstViewOffset = new(0, 2, 2);
    public int active = 3;
    
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            active = (active == 3 ? 1 : 3);
        }
    }

    void LateUpdate()
    {
        if (active == 3)
        {
            transform.position = player.transform.position + thirdViewOffset;
        }
        else
        {
            transform.position = player.transform.position + firstViewOffset;
        }
    }
}
