using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    //Todas las variables que usan Serialize field permiten asignar valores u gameobjects desde el editor 
    [SerializeField] private Bullet bullet;         //Permite asignar un Gameobject que tenga como component el script Bullet
    [SerializeField] private GameObject bulletGo;   //Permite asignar un Gameobject cualquiera
    [SerializeField] private Transform bulletStartPosition; //Permite asignar un Gameobject cualquiera porque todos los Gameobjects tienen el componente Transform
    
    [SerializeField] private int bulletDamage;  //Permite asignar un valor entero como daño de las balas

    [SerializeField] private float cooldownShooting = 0.5f; //Permite modificar la rapidez según la cual se puede volver a disparar

    private float _timeNextShoot = 0f;  //Esta variable no se puede asignar desde el editor y solo se usa para cálculos internos

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        /* La clase Input es una clase de Unity que nos permite leer el Input del jugador desde varios periféricos.
         * En este caso GetKeyDown lee solo una vez el input cuando la tecla es presionada, mientras que GetAxis
         * lee continuamente mientras el botón del mouse asignado este presionado.
         * Si se quisiera leer solamente una vez el botón izquierdo del mouse podemos usar una función como
         * Input.GetMouseButtonDown(0)
        */
        if (Input.GetKeyDown(KeyCode.V) || Input.GetAxis("Fire1") != 0)
        {
            //Si el tiempo suficiente no ha transcurrido no sucede nada y solo se retorna
            if (Time.time <= _timeNextShoot) return;
            
            //Calcula el tiempo del siguiente disparo en base a la variable cooldownShooting
            _timeNextShoot = Time.time + cooldownShooting;
            
            //La función Instantiate crea un nuevo prefab en la escena del objeto asignado.
            //Se puede instanciar desde un script ligado a un Gameobject  
            Bullet bulletInstance = Instantiate(bullet, bulletStartPosition.position, Quaternion.identity);
            
            //O desde un Gameobject directamente como se ve a continuación
            //Gameobject bulletInstance = Instantiate(bulletGo, bulletStartPosition.position, Quaternion.identity);

            bulletInstance.damage = bulletDamage;
        }
    }
}
