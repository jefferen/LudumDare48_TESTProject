using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseEffect : MasterEffect
{
    public override void DoEffect()
    {
        StartCoroutine(Rise());
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }

    public IEnumerator Rise()
    {
        float apex = Random.Range(1.0f, 3.0f);
        while (MyTransform.position.y < apex)
        {
            MyTransform.position = new Vector3(MyTransform.position.x, MyTransform.position.y + 0.001f, MyTransform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }
}
