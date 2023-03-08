using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    private float _speed=3;

    [SerializeField]
    private float _tiempoDeAutodestruccion=3;

    private GUIManager _gui;

    void Start(){

        Destroy(gameObject, _tiempoDeAutodestruccion);

        //ESTO VA A CAMBIAR
        GameObject guiGO= GameObject.Find("GUIManager");

        Assert.IsNotNull(guiGO,"No hay GUIManager");
        _gui= guiGO.GetComponent<GUIManager>();
        Assert.IsNotNull(_gui,"GUIManager no tiene componente");

        // Esto reemplaza las 4 lineas de arriba
        _gui=GUIManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, _speed*Time.deltaTime,0);
    }

    void OnTriggerEnter(Collider c){
        print("Collider Enter"+c.transform.name);
        Destroy(gameObject,0);
    }

}
