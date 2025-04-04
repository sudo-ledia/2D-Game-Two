using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectProjectile : BaseProjectile
{
    public GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        targetEnemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        thisObject.transform.position += VectorToPlayer() * speed;
    }

    Vector3 VectorToPlayer()
    {
        Vector3 targetDirection;
        targetDirection = targetEnemy.transform.position - transform.position;
        targetDirection = targetDirection.normalized;
        return targetDirection;
    }
}
