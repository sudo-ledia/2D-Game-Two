using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : CharacterBase
{
    // Start is called before the first frame update
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Colliding with enemy");
            health = health - 1;
            Destroy(collision.gameObject);
        }
    }
}
