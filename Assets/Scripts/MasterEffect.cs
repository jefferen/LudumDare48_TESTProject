using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEffect : MonoBehaviour
{
    public GameObject MyGameObject;
    public Transform MyTransform;
    public int PercentageOfEffectToHappend;
    bool IsFalling = false;

    public void Awake()
    {
        MyGameObject = gameObject;
        MyTransform = MyGameObject.transform;
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Log") && !IsFalling) DestructionFall();
        if (other.gameObject.CompareTag("Player")) DoEffect();
    }

    public virtual void DoEffect()
    {
        
    }
    public void DestructionFall()
    {
        IsFalling = true;
        Rigidbody rb = new Rigidbody();
        MyGameObject.AddComponent(rb.GetType());
    }
}
