using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipName : MonoBehaviour
{
    private TextMeshPro _shipName;
    public void SetShipName(string ship)
    {
        //GetComponentInChildren es otra forma de obtener un componente, este busca en los gameobjects que sean child
        //de este gameobject y retorna el primero que encuentre
        _shipName = GetComponentInChildren<TextMeshPro>();
        if (ship != "")
        {
            _shipName.text = ship;    
        }
    }
}
