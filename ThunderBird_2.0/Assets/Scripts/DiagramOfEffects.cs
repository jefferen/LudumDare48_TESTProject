using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagramOfEffects : MonoBehaviour
{
    public List<MasterEffect> myEffects;
    public int Count { get => myEffects.Count; }

    public void SetEffects()
    {
        // diagram of effects has a list of effects and the effects has a percentage chance to get set, but you most manualy set the percentage and calculate that they add up to 100%
    }

    public void AddEffect(MasterEffect effect)
    {
        myEffects.Add(effect);
    }
}
