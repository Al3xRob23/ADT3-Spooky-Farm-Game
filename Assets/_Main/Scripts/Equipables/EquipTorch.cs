using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTorch : MonoBehaviour
{
    public GameObject Torch;
    private bool isActive;

    public void EquipTorchItem()
    {
        if (isActive == false)
        {
            Torch.SetActive(true);
            isActive = true;
        }
        else
        {
            Torch.SetActive(false);
            isActive = false;
        };


    }


    
}
