using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    public virtual string Name
    {
        get
        {
            return "_base item_";
        }
    }
    public Sprite _Image;
    public Sprite Image 
    {
        get 
        {
            return _Image;
        }
    }

    public virtual void OnUse()
    {
        //La posició local del objecte l'agafarà dels valors que hem introduit
        transform.localPosition = PickPosition;
        //La rotació local del objecte l'agafarà dels valors que hem introduit
        transform.localEulerAngles = PickRotation;
    }

    public virtual void OnDrop()
    {
        //Explicat a NavMesh. Utilitzar la càmera que saber quin punt de la pantalla ha tocat el mouse
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
            gameObject.transform.eulerAngles = DropRotation;
        }
    }
    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    //Posició de la destral a la mà. Posada manualment
    public Vector3 PickPosition;

    //Rotació de la destral a la mà. Posada manualment
    public Vector3 PickRotation;

    //Restablir la Rotació
    public Vector3 DropRotation;

}
