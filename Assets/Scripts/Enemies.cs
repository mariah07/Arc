using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{

    public float detectplayer = 4f;

    private float distance;

    public Gun gun;

    Transform player;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = PlayerManager.instance.player.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if(distance <= detectplayer)
        {
            gun.firing = true;
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
