using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform target;

    void Start()
    {
    target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.5F);
    }

 

}
