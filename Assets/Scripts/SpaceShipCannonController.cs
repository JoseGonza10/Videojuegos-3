using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipCannonController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Projectil a lanzar")]
    GameObject projectilePrefab;

    [SerializeField]
    [Tooltip("Cañon derecho de nave")]
    Transform rightFirePoint;

    [SerializeField]
    [Tooltip("Cañon izquierdo de nave")]
    Transform leftFirePoint;

    
    bool _inputFire;

    bool _isFiring;

    void Update()
    {
        handleInputs();
        handleFire();
    }

    void handleFire()
    {
        if (_isFiring)
        {
        Instantiate(projectilePrefab, rightFirePoint.position, rightFirePoint.rotation);
        Instantiate(projectilePrefab, leftFirePoint.position, leftFirePoint.rotation);
        }
    }

    void handleInputs()
    {
        _inputFire = Input.GetButton("Fire1");

        _isFiring = _inputFire != false;
    }
}
