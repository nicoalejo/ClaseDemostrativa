using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputShipName; //Referencia al component TextMeshProUGUI para el ingreso del nombre de la nave
    [SerializeField] private GameObject player; //Referencia al gameobject de la nave
    [SerializeField] private GameObject spawner; //Referencia al gameobject spawner

    private GameObject _panelUI;
    private ShipController _playerShipController;
    void Start()
    {
        //Esta es otra forma (menos eficiente y más propensa a fallas) de buscar objectos a través del Tag que tengan 
        _panelUI = GameObject.FindGameObjectWithTag("PanelUI");
        
        //A continuación otras maneras, igual menos eficientes y que deberian evitarse, pero que pueden ser necesarias
        //en algún caso:
        
        //Busca un gameobject activo por el nombre que tenga en la escena
        //_player = GameObject.Find("Ship");
        
        //Busca un gameobject basándose en un script o componente que tenga, si se quiere asignar es necesario hacer un casting 
        //hacia el tipo de objeto o script de destino
        //_playerShipController = (ShipController) GameObject.FindObjectOfType(typeof(ShipController));
        
        //Funciona exactamente igual que FindGameObjectWithTag
        //_player = GameObject.FindWithTag("Player");
        
    }
    
    //Esta función se llamará cuando se de click al botón New Game, usando Unity Events. 
    public void NewGame()
    {
        if (_panelUI != null)
        {
            //Desactiva el panel
            _panelUI.SetActive(false);
            
            //Activa el player y el spawner para que se pueda comenzar a jugar
            player.SetActive(true);
            spawner.SetActive(true);
            
            //Recoge el script ShipName del gameobject player y usa la función publica SetShipName para pasar el nombre 
            //ingresado en el Inputfield del inicio
            ShipName shipName = player.GetComponent<ShipName>();
            shipName.SetShipName(inputShipName.text);
        }
    }
}
