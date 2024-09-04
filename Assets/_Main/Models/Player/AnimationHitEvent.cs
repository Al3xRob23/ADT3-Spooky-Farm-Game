using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationHitEvent : MonoBehaviour
{
    public GameObject parent;
    //public void AE_Hit(string s) => Debug.Log("AE_Hit called at" + Time.time + " with a value of " + s);

    public void AE_Hit()
    {
        parent.GetComponent<SimpleFPSController>().EnemyHit();
    }
}

