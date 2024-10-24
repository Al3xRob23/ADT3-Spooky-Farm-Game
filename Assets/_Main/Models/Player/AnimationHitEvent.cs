using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationHitEvent : MonoBehaviour

{
    public GameObject parent;
    //public void AE_Hit(string s) => Debug.Log("AE_Hit called at" + Time.time + " with a value of " + s);
    public Animator Animator;
    public AudioSource clip;

    public void AE_Hit()
    {
        parent.GetComponent<SimpleFPSController>().EnemyHit();
        clip.Play();
        Invoke("SetObjRotation", 0.8f); 
    }

    public void SetObjRotation()
    {
        Animator.transform.localRotation = Quaternion.Euler(0, 0, 0);
        Animator.transform.localPosition = new Vector3(0.12f, -0.5f, 0.08f);
    }
}

