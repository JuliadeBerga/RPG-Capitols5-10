using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    //Creem aquesta variable pq el inventari sàpiga quan ha d'utilitzar el inventari
    public Inventory _Inventory;

    //Funció que s'executa quan es clica l'item del inventari
    //A Border haurem d'afegir un Add Component On Click() i quan es cliqui Border entrarà aquesta funció
    public void OnItemClicked()
    {
        ItemDragHandler dragHandler= 
        //Busquem la imatge que hi ha al inventari
        gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        //Guardem aquest item a item
        IInventoryItem item = dragHandler.Item;

        //Treiem per consola el nom del item per verificar que funciona
        Debug.Log(item.Name);

        //Cridem a UseItem, enviant-li el paràmetre item
        //Com que no existeix (dona error), botó dret i refactoring i generar mètode a Inventory
        _Inventory.UseItem(item);

        //Afegim un nou mètode
        item.OnUse();


    }
}
