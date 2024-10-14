using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyItemsUI : MonoBehaviour
{
    public Image LockedShotgunFrame;
    public Image LockedShotgunPump;
    public Image LockedShotgunPart;
    public Image LockedShotgunBarrel;


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
            case ItemID.ShotgunPump:
                UnlockEgg();
                break;
            case ItemID.ShotgunFrame:
                UnlockKeys();
                break;
            case ItemID.ShotgunPart:
                UnlockZombieHead();
                break;
            case ItemID.ShotgunBarrel:
                UnlockFigures();
                break;

        }
    }

    public void UnlockEgg()
    {
        LockedShotgunPump.enabled = false;
    }
    public void UnlockKeys()
    {
        LockedShotgunFrame.enabled = false;
    }
    public void UnlockZombieHead()
    {
        LockedShotgunPart.enabled = false;
        FindObjectOfType<CompassBarUI>().one.enabled = false;
    }
    public void UnlockFigures()
    {
        LockedShotgunBarrel.enabled = false;
    }
}
