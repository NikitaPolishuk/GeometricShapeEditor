using Assets.Scripts.Interfaces;
using Assets.Scripts.Model;
using UnityEngine;


namespace Asset.Scripts.Factory
{
    public class SphereFactory : IShapeFactory
    {
        public IShape CreateShape(Transform parent)
        {
            var go = GameObject.Instantiate(new GameObject("Sphere"), parent);
            var prism = go.AddComponent<Sphere>();
            prism.Init();
            return prism;
        }
    }
}
