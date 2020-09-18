using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float bulspeed;

    public Bullet bullet;
    public bool firing;
    private float count;

    public Transform firepoint;

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            count -= Time.deltaTime;
            if(count <= 0)
            {
                count = 0.2f;
                Bullet newBullet = Instantiate(bullet, firepoint.position, firepoint.rotation) as Bullet;
                newBullet.speed = bulspeed;
                
            }
        }
        else
        {
            count = 0;
        }

        
    }

}
