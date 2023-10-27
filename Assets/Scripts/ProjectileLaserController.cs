using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaserController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Fuerza con la viaja el projectile")]
    float force;

    float _projectileLifeSpan = 5F;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0.0F, force, 0.0F), ForceMode.Force);
        Destroy(this.gameObject, _projectileLifeSpan);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            Destroy(collision.gameObject);
        
    }
}
