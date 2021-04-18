using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject GridCube;
    List<GameObject> MyGridCubes;
    [Range(0,50)]
    public int Size;
    public List<int> OutComePercentage;
    public DiagramOfEffects MyDiagramOfEffects;

    void Start()
    {
        MyGridCubes = new List<GameObject>();

        for (int i = 0; i < MyDiagramOfEffects.myEffects.Count; i++)
        {
            MyDiagramOfEffects.myEffects[i].PercentageOfEffectToHappend = OutComePercentage[i];
        }

        CreateGrid(Size);
        SetGridEffects(MyDiagramOfEffects);
    }

    public void CreateGrid(int Size)
    {
        for (int i = 0; i < Size * 4; i+=4)
        {
            for (int j = 0; j < Size * 4; j+=4)
            {
                GameObject g = Instantiate(GridCube, new Vector3(i, 0, j), Quaternion.identity);
                MyGridCubes.Add(g);
            }
        }
    }

    public void SetGridEffects(DiagramOfEffects diagramOfEffects, bool HaveVoidOutCome = false) 
    {
        if (HaveVoidOutCome) diagramOfEffects.AddEffect(new NoEffect());
        List<int> percentagePoints = new List<int>();


        int pecrent = 0;
        for (int i = 0; i < diagramOfEffects.myEffects.Count; i++)
        {
            pecrent += diagramOfEffects.myEffects[i].PercentageOfEffectToHappend;
            percentagePoints.Add(pecrent);
        }

        foreach (var item in MyGridCubes)
        {
            int index = Random.Range(0, 100 - 1);

            for (int i = 0; i < diagramOfEffects.Count; i++)
            {
                if(i == 0) // if first index
                {
                    if (index < percentagePoints[i]) item.AddComponent(diagramOfEffects.myEffects[i].GetType()); 
                }
                else
                {
                    //if (i == diagramOfEffects.Count && HaveVoidOutCome) item.AddComponent(diagramOfEffects.myEffects[diagramOfEffects.Count].GetType());

                    if (index < percentagePoints[i] && index > percentagePoints[i-1]) item.AddComponent(diagramOfEffects.myEffects[i].GetType());
                }
               
            }
        }
    }
}
