using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesController : MonoBehaviour
{

    void Start()
    {
        IShapeFactory factory = new PrismFactory();
        IShape prism = factory.CreateShape();
        prism.UpdateMesh(6, 5f, 5);
    }

}
