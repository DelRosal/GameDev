using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class GUIManager : MonoBehaviour
{

    // Singleton
    // Design pattern que limita la creacion de objetos de una clase a solo 1
    // Lo hace limitando el acceso al constructor
    // Por las restricciones de unity el lugar de constructor privado vamos a borrar las instancias
    private static GUIManager _instance;

    // PROPERTIES
    // Mecanismo para dividir quien puede leer/ escribir una variable
    // Podemos utilizarlos con variables explicitamente declaradas
    private float _dummy1;

    // Escribiendo propiedad
    // No es necesario declarar ambos get y set

    public float Dummy1
    {
        get{ return _dummy1;}
        private set{ _dummy1=value;}
    }

    public float Dummy1b
    {
        get{ return _dummy1;}
    }

    // Propiedad con variable anonima 
    
    public static GUIManager Instance 
    {
        get{return _instance;}
    }
    
    public float _dummy2
    {
        get;
        private set;
    }

    [SerializeField]
    public TMP_Text _text; 

    void Awake()
    {

        // PRUEBAS CON PROPIEDADES
        Dummy1= 4.2f;
        print (Dummy1);

        // Checar si alguien ya poblo la referencia de instancia
        if(_instance!=null)
        {
            //Ya existia el objeto entonces me borro
            Destroy(this);
            return;

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_text,"Texto no puede ser nulo");
        _text.text="Hello World";
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
