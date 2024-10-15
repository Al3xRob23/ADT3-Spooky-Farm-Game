using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTorch : MonoBehaviour
{
    public GameObject Torch;

    public void EquipTorchItem()
    {
        Torch.SetActive(true);
    }


    
}
