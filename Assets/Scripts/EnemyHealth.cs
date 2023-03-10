using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health; //Variable que define la vida de los enemigos

    //Esta función recibe un int que reduce la vida del enemigo, si esta llega a 0 destruye el enemigo 
    private void ReduceHealth(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Esta función es llamada cuando existe una colisión con otro objeto pero no hay interacción de las físicas
    private void OnTriggerEnter(Collider other)
    {
        //TryGetComponent suele ser la mejor manera de obtener un componente, esta función intenta obtener el componente,
        //si lo logra devuelve true y guarda el componente en una variable usando el parámetro out, sino devuelve false.
        if (other.TryGetComponent(out Bullet bullet))
        {
            ReduceHealth(bullet.damage);
        }
        
        //A continuación otras formas de obtener componentes o scripts:
        
        //Parecido a TryGetComponent pero si no encuentra el componente retorna null, lo contraproducente es que no guarda
        //el componente asignado en ninguna variable
        //if(other.GetComponent<Bullet>())
        
        //Se puede usar comparar Tags también para comprobar si el objeto de la colisión es el correcto, pero una vez más
        //se realiza doble trabajo porque si el Tag es correcto se debe usar la función GetComponent o TryGetComponent
        //para obtener el componente o script.
        
        //if(other.CompareTag("Bullet")){
        //  Bullet bullet = other.GetComponent<Bullet>();
        //  ReduceHealth(bullet.damage);
        //}
    }
}
