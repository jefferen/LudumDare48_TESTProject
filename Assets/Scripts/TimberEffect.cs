using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimberEffect : MasterEffect
{
    Object Log;
    Object Timbeeer;

    public void Start() // if it does not exist at startup and rumtime you need to specify the ref to the object to the file location
    {
        Timbeeer = Resources.Load("Sounds/Timber");
        Log = Resources.Load("Prefabs/Log"); // since when did we instantiate from the assets folder like this? just know the ref when i'm setting it in the inspector :/
    } 

    public override void DoEffect()
    {
        Timber();
    }
    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }

    public void Timber()
    {
        Vector3 FallPoint = GameObject.FindGameObjectWithTag("Player").transform.position;

        FallPoint = new Vector3(FallPoint.x + Random.Range(-5.0f,5.0f), 20, FallPoint.z + Random.Range(-5.0f, 5.0f));

        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam.GetComponent<AudioSource>().PlayOneShot((AudioClip)Timbeeer);

        //random.rotation returns a quaternion... you can change that into the eulerAngle representation and grab the y component from it.Then perform a rotation
        // using that component and 0's for x and z.
        // or you can just use random.range and Quaternion.Euler (http://docs.unity3d.com/Documentation/ScriptReference/Quaternion.Euler.html)
        //or you could use random.range in conjunction with AngleAxis(http://docs.unity3d.com/Documentation/ScriptReference/Quaternion.AngleAxis.html) 

        Quaternion q = Random.rotation;
        q = new Quaternion(q.eulerAngles.x, 0, q.eulerAngles.z, 0);

        Instantiate(Log, FallPoint, q);
    }
}
