//Carregar aquesta llibreria perquè funcionin els events
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    // Es fixa que hi haurà 9 espais (slots) en la variable SLOTS
    private const int SLOTS = 9;

    // mItems és una llista referenciada al script InventoryItemY
    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    // Aquí definim 1 event: Afegir un Item
    public event EventHandler<InventoryEventArgs> ItemAdded;

    // Aquí afegim un nou event: Eliminar un Item
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    // Aquí afegim un nou event: Usar un Item
    public event EventHandler<InventoryEventArgs> ItemUsed;

    public void AddItem(IInventoryItem item)
    {
        //Si tinc espai al inventari, o sigui, si hi ha slots lliures
        if (mItems.Count < SLOTS)
        {
            //Creem variable tipus collider i la inicialitzem
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            //Si està habilitada
            if (collider.enabled)
            {
                //la deshabilitem
                collider.enabled = false;

                //Cridem a la funció item
                mItems.Add(item);

                //Cridem a la funció pickup
                item.OnPickup();

                //si hem afegit un item
                if (ItemAdded != null)
                {
                    //item afegit
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    //Generat automàticament dsd ItemClickeHandler per usar l'item
    internal void UseItem(IInventoryItem item)
    {
        //Fem exactament el mateix que amb ItemRemoved()
        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }


    //Aquesta funció elimina el item del inventari
    public void RemoveItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            //Elimina el item de la llista de items
            mItems.Remove(item);

            //Crida a la funció OnDrop()
            item.OnDrop();

            //Reactivem el collider del objecte
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider != null)
            {
                collider.enabled = true;
            }

            //i el item del inventari és eliminat
            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }

        }
    }
}