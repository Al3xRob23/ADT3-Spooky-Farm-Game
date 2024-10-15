using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItemOnPlayer : MonoBehaviour
{
    public GameObject PlayerArms;
    //public Transform tempTransform;
    public Vector3 position;
    private bool IsEquipped;


     public void EquipItem()
    {
        if (IsEquipped == false)
        {
            gameObject.SetActive(true);
            PlayerArms.SetActive(false);
            IsEquipped = true;
        }
        

        else
        {
            gameObject.SetActive(false);
            PlayerArms.SetActive(true);
            IsEquipped = false;
        }

    }



    
    //private void Update()
    //{
    //    EquipSlot.transform.position = transform.position + transform.parent.transform.position;

    //}



    //private void OnTransformParentChanged()
    //{ 

    //    tempTransform.position = gameObject.transform.parent.parent.position;

    //}




   


}
