using UnityEngine;

public class ShipController : MonoBehaviour
{
    //Al usar SerializeField podemos visualizar y cambiar el contenido de la variable desde el editor de unity
    [SerializeField] private float speed;
    
    //La función Update se va a ejecutar 1 vez cada frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        //Si no hay input en el eje "Horizontal" se retorna sin realizar ningún cálculo 
        if (Input.GetAxis("Horizontal") == 0) return; 
        
        //Asignamos a la variable nextShipPos la posición actual de este objeto
        Vector3 nextShipPos = transform.position;
        
        //Siguiente posición de la nave en X
        float nextPosX = nextShipPos.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        
        //Usamos la función Clamp para establecer un valor máximo y mínimo de la variable
        nextShipPos.x = Mathf.Clamp(nextPosX, -91f, 91f);
        
        //Modifica la posición de la nave cada frame. Todos los Gameobjects tiene el componente Transform, que es
        //el que les da su posición en el mundo. Al modificar la variable position de este podemos mover los distintos 
        //gameobjects desde un script
        transform.position = nextShipPos;
    }
}
