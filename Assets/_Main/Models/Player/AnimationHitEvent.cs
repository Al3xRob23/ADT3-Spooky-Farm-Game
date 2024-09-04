using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHitEvent : MonoBehaviour

{
    public void AE_Hit(string s) => Debug.Log("AE_Hit called at" + Time.time + " with a value of " + s);
    


}

