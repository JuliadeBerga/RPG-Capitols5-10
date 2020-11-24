//Carregar aquesta llibreria perquè funcionin els events
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInventoryItem
{
    //Haurem de posar un nom al objecte interactuable creat
    string Name { get; }

    //Haurem de associar una imatge
    Sprite Image { get; }

    //Definim la funció OnPickup
    void OnPickup();

    //Afegim la funció OnDrop a la interficie del IInventoryItem
    void OnDrop();

}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}


