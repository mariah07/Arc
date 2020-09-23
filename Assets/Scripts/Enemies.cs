using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{

    public float detectplayer;

    public float speed;

    private float distance;

    public float health;

    public Gun gun;

    private Player_Movement thePlayer;

    private Rigidbody enemy;

   // private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        thePlayer = FindObjectOfType<Player_Movement>();
        enemy = GetComponent<Rigidbody>();
       
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

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        enemy.velocity = (transform.forward * speed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectplayer);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag.Equals("damage")) 
            {
                health -= 5;
            } 
    }
}
