using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    public GameObject projectile;
    public float spawnTimer = 0f;
    public float spawnInterval = 1f;

    public float dmgTimer = 0f;
    public float dmgInterval = 2f;
    // Start is called before the first frame update

    void Update()
    {   
        dmgTimer += Time.deltaTime;
        Health();
        DisplayHealth();
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            spawnTimer = 0f;
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(dmgTimer >= dmgInterval)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Debug.Log("Colliding with enemy");
                health = health - 1;
                //Destroy(collision.gameObject);
            }

            dmgTimer = 0f;
        }
    }

    // public override void Health()
    // {
    //     if (health >= 0)
    //     {
    //         this.enabled = false;
    //     }
    // }
}
