using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceHandler
{
    private Dictionary<CellObjectType, Material> matDict= new Dictionary<CellObjectType, Material>();
    private Material defaultMat = Resources.Load<Material>("Materials/Default");

    public ResourceHandler()
    { 
        Material[] mats = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray();

        // Zuweisung der Texturen zu Zell-Typen
        matDict.Add(CellObjectType.Empty, mats[0]);
        matDict.Add(CellObjectType.Road, mats[1]);
    }

    public Material getMaterial(CellObjectType Type)
    { 
        foreach(var pair in matDict)
        {
            if (pair.Key == Type) return pair.Value;
        }
        return defaultMat;
    }
}
