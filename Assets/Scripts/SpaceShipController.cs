using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    //Para moverse en el eje z
    [Header("Movement")]

    [SerializeField]
    [Tooltip("Z axis")]
    float forwardSpeed = 30; //Velocidad para moverse hacia adelante

    [SerializeField]
    [Tooltip("Velocidad de forward automatico")]
    float autoForwardSpeed; //Velocidad para moverse hacia adelante cuando se deja de apretar forward en velocidad personalizada

    [SerializeField]
    [Tooltip("X axis")]
    float strafeSpeed = 8.0F; //Velocidad para moverse en izquierda o derecha

    [SerializeField]
    [Tooltip("Y axis")]
    float hoverSpeed = 5.0F; //Velocidad para moverse de arriva hacia abajo

    

    [Header("Acceleration")]

    [SerializeField]
    float forwardAcceleration = 2.5F;

    [SerializeField]
    float strafeAcceleration = 2.0F;

    [SerializeField]
    float hoverAcceleration = 2.0F;

    [Header("Roll")]
    float rollSpeed = 85.0F;
    
    [SerializeField]
    float rollAcceleration = 1.5F;
    
    Rigidbody _rb;


    float _activeForwardSpeed;
    float _activeStrafeSpeed;
    float _activeHoverSpeed;

    float _lookRateSpeed = 75.0F;
    float _rollInput;

    Vector2 _lookInput;
    Vector2 _screenCenter;
    Vector2 _mouseDistance;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

   
    void Start()
    {
        _screenCenter = new Vector2(Screen.width * 0.5F, Screen.height * 0.5F);
    }
    
    void Update()
    {
        HandleInputs();
    
    }

    void FixedUpdate()
    {
        transform.Rotate(-_mouseDistance.y * _lookRateSpeed * Time.fixedDeltaTime, _mouseDistance.x * _lookRateSpeed * Time.fixedDeltaTime,
            _rollInput * rollSpeed * Time.deltaTime,Space.Self);

        _rb.position += transform.forward * _activeForwardSpeed * Time.fixedDeltaTime;
        _rb.position += transform.right * _activeStrafeSpeed * Time.fixedDeltaTime;
        _rb.position += transform.up * _activeHoverSpeed * Time.fixedDeltaTime;
    }

    void HandleInputs()
    {
        _lookInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        _mouseDistance = new Vector2((_lookInput.x - _screenCenter.x) / _screenCenter.x,
            (_lookInput.y - _screenCenter.y) / _screenCenter.y);

        _mouseDistance = Vector2.ClampMagnitude(_mouseDistance, 1.0F);

        _rollInput = Mathf.Lerp(_rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        float currentForwardSpeed;
        if (Input.GetAxisRaw("Forward") < 1 )
        {
            currentForwardSpeed = autoForwardSpeed;
        }
        else
        {
            currentForwardSpeed = Input.GetAxisRaw("Forward") * forwardSpeed;
        }
        _activeForwardSpeed = Mathf.Lerp(_activeForwardSpeed, currentForwardSpeed, forwardAcceleration * Time.deltaTime);
        //_activeForwardSpeed = Input.GetAxisRaw("Vertical") * forwardSpeed;
        float currentStrafeSpeed = Input.GetAxisRaw("Horizontal") * strafeSpeed;
        _activeStrafeSpeed = Mathf.Lerp(_activeStrafeSpeed, currentStrafeSpeed, strafeAcceleration * Time.deltaTime);
        //_activeStrafeSpeed = Input.GetAxisRaw("Horizontal") * strafeSpeed;
        float currentHoverSpeed = Input.GetAxisRaw("Hover") * hoverSpeed;
        _activeHoverSpeed = Mathf.Lerp(_activeHoverSpeed, currentHoverSpeed, hoverAcceleration * Time.deltaTime);
        //_activeHoverSpeed = Input.GetAxisRaw("Hover") * hoverSpeed;
    }

}
