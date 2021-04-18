using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEffect : MasterEffect
{
    public override void DoEffect()
    {
        Invoke("Delay", 0.2f); // make sound
    }

    void Delay()
    {
        StartCoroutine(Fall());
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }

    public IEnumerator Fall()
    {
        while (MyTransform.position.y > -6)
        {
            MyTransform.position = new Vector3(MyTransform.position.x, MyTransform.position.y - 0.03f, MyTransform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }
}
