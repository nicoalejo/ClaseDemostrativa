using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 15f; //Velocidad de movimiento del enemigo

    void Update()
    {
        EnemyMovement();
    }
    
    //Esta función revisa la posición del enemigo, si esta por fuera de la pantalla lo destruye
    private void InScreenRange()
    {
        if (transform.position.x > 120)
        {
            Destroy(gameObject);
        }
    }
    
    //Se llama desde el Update, y modifica la posición del enemigo en el eje X cada frame
    private void EnemyMovement()
    {
        transform.position += new Vector3(enemySpeed * Time.deltaTime, 0f, 0f);
        InScreenRange();
    }
}
