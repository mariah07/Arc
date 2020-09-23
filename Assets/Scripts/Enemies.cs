using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{

    public float detectplayer = 4f;

    private float distance;

    public Gun gun;

    private Player_Movement thePlayer;

    private Rigidbody rb;

   // private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        thePlayer = FindObjectOfType<Player_Movement>();
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(thePlayer.transform.position, transform.position);
        

        if (distance <= detectplayer)
        {
            gun.firing = true;
            transform.LookAt(thePlayer.transform.position);
           
        }
        else
        {
            gun.firing = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectplayer);
    }
}
