using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyItemsUI : MonoBehaviour
{
    public Image LockedKeys;
    public Image LockedEgg;
    public Image LockedZombieHead;
    public Image LockedFigures;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void HandleItemAdded(ItemID id)
    {
        switch (id)
        {
            case ItemID.CursedEgg:
                UnlockEgg();
                break;
            case ItemID.Key:
                UnlockKeys();
                break;
            case ItemID.ZombieHead:
                UnlockZombieHead();
                break;
            case ItemID.CollectableFigures:
                UnlockFigures();
                break;

        }
    }

    public void UnlockEgg()
    {
        LockedEgg.enabled = false;
    }
    public void UnlockKeys()
    {
        LockedKeys.enabled = false;
    }
    public void UnlockZombieHead()
    {
        LockedZombieHead.enabled = false;
        FindObjectOfType<CompassBarUI>().one.enabled = false;
    }
    public void UnlockFigures()
    {
        LockedFigures.enabled = false;
    }
}
