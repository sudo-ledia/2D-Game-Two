using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    public GameObject projectile;
    public float spawnTimer = 0f;
    public float spawnInterval = 1f;
    // Start is called before the first frame update

    void Update()
    {   
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            spawnTimer = 0f;
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Colliding with enemy");
            health = health - 1;
            //Destroy(collision.gameObject);
        }
    }
}
