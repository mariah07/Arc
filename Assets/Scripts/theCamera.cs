using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theCamera : MonoBehaviour
{
    public float height;
    public Transform player;
    public float smooth = 0.3f;

    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y + height, player.position.z - 4f);
    
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
