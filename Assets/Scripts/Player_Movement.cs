using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody player;
    private Vector3 minput;
    private Vector3 mvelocity;

    public Gun gun;

    public float speed;
    private bool shield = false;

    private Camera mainCamera;
    private Vector3 direction; 

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        minput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        mvelocity = minput * speed;

        Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(camRay, out rayLength))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            gun.firing = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            gun.firing = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            shield = true;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (shield == true)
        {
            direction = (-col.attachedRigidbody.velocity);
            col.attachedRigidbody.velocity = direction;
        }
    }


    void FixedUpdate()
    {
        player.velocity = mvelocity;
    }
}
