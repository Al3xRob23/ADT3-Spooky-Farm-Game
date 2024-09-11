using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemOnPlayer : MonoBehaviour
{
    public GameObject EquipSlot;
    //public Transform tempTransform;
    public Vector3 position;


     public void EquipItem()
    {
        gameObject.SetActive(true);

    }


    public void DequipItem()
    {
        gameObject.SetActive(false);
    }

    
    private void Update()
    {
        EquipSlot.transform.position = transform.position + transform.parent.transform.position;

    }



    //private void OnTransformParentChanged()
    //{ 

    //    tempTransform.position = gameObject.transform.parent.parent.position;

    //}




   


}
