using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterBase
{
    public float speed;
    public float xSpeed;
    public float ySpeed;

    public GameObject thisObject;
    public float xDir = 0f;
    public float yDir = 0f;

    public GameManager manager;

    public float reverseTime = 0f;
    public float reverseInterval = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(xSpeed, ySpeed);
        xDir = Random.Range(-1f,1f);
        yDir = Random.Range(-1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayHealth();
        Health();
        
        manager = FindObjectOfType<GameManager>();
        thisObject.transform.position += new Vector3(xDir, yDir, 0) * speed;
        reverseTime += Time.deltaTime;
        if(reverseTime >= reverseInterval)
        {
            reverseTime = 0f;
            xDir = xDir * -1;
            yDir = yDir * -1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectile")
        {
            health = health - 1;
            Destroy(other.gameObject);
            // Destroy(gameObject);
        }
    }

    public override void Health()
    {
        if(health <= 0)
        {   
            manager.enemyCounter--;
            manager.money++;
            Destroy(gameObject);
        }
    }
}
