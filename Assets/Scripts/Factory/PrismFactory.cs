using Assets.Scripts.Interfaces;
using Assets.Scripts.Model;
using UnityEngine;

public class PrismFactory : IShapeFactory
{
    public IShape CreateShape()
    {
        var go = new GameObject("Prism");
        var prism = go.AddComponent<Prism>();
        prism.Init();
        return prism;
    }
}
