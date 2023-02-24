// Estamos utilizando .NET
// Aquí "importamos" namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// Esta linea obliga la presencia de un componente en el GambeObject
// Todos tienen transform pero es un ejemplo
[RequireComponent (typeof(Transform))]


public class Movimiento : MonoBehaviour
{

    private Transform _transform;

    // Permite modificar valor en el editor sin hacerlo publico
    [SerializeField]
    private float _speed;


    // Start is called before the first frame update

    // Ciclo de vida/ Lifecyle
    // Existen métodos que se invocan en momentos específicos de la vida del script


    // Se invoca una vez al inicio de la vida de un componente
    // Otra diferencia- awake se invoca aunque objeto este deshabilitado
    void Awake()
    {
        print("AWAKE");

    }

    // Se invoca una vez que se terminan de invocar todos los awakes
    void Start()
    {
        Debug.Log("START");

        // Como obtener referencia a otro componente
        // GetComponent es lento, debe hacerse la menor cantidad de veces posible 
        // Con transform ya tenemos referencia
        // Esta operacion puede regresar nulo
        _transform= GetComponent<Transform>();

        // Si tiene requiere esto ya no es necesario
        // Assert verifica una variable/operacion contra un valor
        Assert.IsNotNull(_transform, "Es necesario para movimiento tener un transform");
    }

    // Update is called once per frame
    // Frame/Cuadro/Fotograma
    // Target mínimo - 30 fps
    // Ideal - 60+ fps
    void Update()
    {
        // Siempre vamos a tratar que este metodo sea lo más pequeño posible
        // Entrada de Usuario
        // Movimiento

        // Polling por dispositivo

        // True cuando en el cuadro anterior estaba libre 
        // y en el actual esta presionado
        if(Input.GetKeyDown(KeyCode.Z))
        {
            print("KEY DOWN Z ");
        }
        // True cuando en el cuadro anterior estaba presionado 
        // y en el actual sigue presionado
        if(Input.GetKey(KeyCode.Z))
        {
            print("KEY Z");
        }
        // True cuando en el cuadro anterior estaba presionado 
        // y en el actual no esta presionado
        if(Input.GetKeyUp(KeyCode.Z))
        {
            print("KEY UP Z");
        }

        if(Input.GetMouseButtonDown(0)){
            print("Mouse Button Down");
        }
        if(Input.GetMouseButton(0))
        {
            print("Mouse Button");
        }
        if(Input.GetMouseButtonUp(0))
        {
            print("Mouse Button Up");
        }


        // Ejes
        // Mapea manejo de Hardware a ub valor abstracto llamado eje
        // Rango [-1,1]

        // Raw es movimiento total (0-1, 0,-1), sino tiene una suavizacion
        float horizontal= Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxis("Vertical");
        //print(horizontal+"  "+vertical);

        if (Input.GetButtonDown("Jump"))
        {print("Jump");}

        // Movimiento
        // 1. Directamente con Transform
        // 2. Character Controller
        // 3. Motor de fisica
        // 4. Navmesh (AI)

        // Space.World es eje comparado al mundo, Space.Self eje comparado a si mismo
        // deltaTime permite el movimiento constante sin importar la velocidad de la computadora

        _transform.Translate(_speed*Time.deltaTime, 0, 0, Space.World);


    }

    // Update que corre en intervalo fijado en la configuración del proyecto
    // NO puede correr más frecuentemente que Update
    void FixedUpdate()
    {}

    // Corre todos los cuadros
    // Una vez que los updates estan terminados
    void LateUpdate()
    {}
}
