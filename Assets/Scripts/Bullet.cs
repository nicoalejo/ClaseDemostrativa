using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variable que define la velocidad a la que se trasladan las balas
    [SerializeField] private float bulletSpeed = 10f;
    
    //Si una variable es pública siempre se mostrará en el inspector al igual que cuando usamos SerializeField,
    //si no queremos que esto suceda podemos usar HideInInspector, como se hace a continuación
    [HideInInspector]
    public int damage;
    
    //A continuación otras maneras en las que se puede exponer una variable:
    
    //Variable privada, con funciones separadas de Get y Set
    
        // private int _damage;
        //
        // public void SetDamage(int dmg)
        // {
        //     _damage = dmg;
        // }
        // public int GetDamage()
        // {
        //     return _damage;
        // }
        
    //Variable privada con función anónima para Get
    
        // private int _damage;
        // public int Damage => _damage;
        
    //Variable pública con definiciones internas de get público y set privado

        // public int Damage { get; private set; } = 5;
    
        
    //El start correrá una sola vez al momento en el que se instancian las balas
    private void Start()
    {
        //La duración de las balas es como máximo 5 segundos, luego de esto la función Destroy destruirá el gameobject
        //al cual este asignado este script
        Destroy(gameObject, 5f);
    }
    
    void Update()
    {
        //Calcula y modifica cada frame la posición de la bala en el eje Z
        transform.position += new Vector3(0, 0, bulletSpeed * Time.deltaTime);
    }

    //Se ejecuta cuando comienza un evento de gatillo (Trigger), es decir un tipo de colisión que no tiene consecuencias físicas
    private void OnTriggerEnter(Collider other)
    {
        //La variable other contiene el otro objeto con quien fue la colisión.
        //Y comparamos si el Tag de ese objeto es "Enemy"
        if (other.CompareTag("Enemy"))
        {
            //Si lo es procedemos a destruir la bala
            Destroy(gameObject);    
        }
    }
}
