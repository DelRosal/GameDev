using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;



public class Movimiento : MonoBehaviour
{

    private Transform _transform;

    [SerializeField]
    private float _speed=1;

    [SerializeField]
    private GameObject _disparoOriginal;


    void Awake()
    {
        print("AWAKE");

    }

    void Start()
    {
        Debug.Log("START");

        _transform= GetComponent<Transform>();

        Assert.IsNotNull(_transform, "Es necesario para movimiento tener un transform");
        Assert.IsNotNull(_disparoOriginal,"Dispario no puede ser nulo");
        //Assert.IsNotEqual(0,_speed, "Velocidad debe ser mayor a 0");
    }


    void Update()
    {

        // Ejes
        // Mapea manejo de Hardware a ub valor abstracto llamado eje
        // Rango [-1,1]

        // Raw es movimiento total (0-1, 0,-1), sino tiene una suavizacion
        float horizontal= Input.GetAxis("Horizontal");
        float vertical= Input.GetAxis("Vertical");
        //print(horizontal+"  "+vertical);

        _transform.Translate(horizontal*_speed*Time.deltaTime, vertical*_speed*Time.deltaTime, 0, Space.World);

        if (Input.GetButtonDown("Jump"))
        {
            print("Jump");
            //se pueden hacer GameObject vacios
            //GameObject= new GameObject();

            //Si queremos un GameObject predefinido, para clonar usamos Instantiate
            Instantiate(_disparoOriginal, 
                        transform.position, 
                        transform.rotation);

        }

    }

    void FixedUpdate()
    {}

    void LateUpdate()
    {}
}
