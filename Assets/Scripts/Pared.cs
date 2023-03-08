using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;



public class Pared : MonoBehaviour
{

    private Transform _transform;

    [SerializeField]
    private GameObject _ataqueOriginal;

    void Start()
    {
        Debug.Log("START");

        _transform= GetComponent<Transform>();

        Assert.IsNotNull(_transform, "Es necesario para movimiento tener un transform");
        Assert.IsNotNull(_ataqueOriginal,"Dispario no puede ser nulo");
        //Assert.IsNotEqual(0,_speed, "Velocidad debe ser mayor a 0");
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_ataqueOriginal, 
                        new Vector3(Random.Range(-3.0f,3.0f),5.0f,0), 
                        transform.rotation);
        }

    }

}
