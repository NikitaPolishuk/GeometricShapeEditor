using Assets.Scripts.Interfaces;
using Assets.Scripts.Model;
using UnityEngine;

namespace Asset.Scripts.Factory
{
    public class PrismFactory : IShapeFactory
    {
        public IShape CreateShape(Transform parent)
        {
            var go = GameObject.Instantiate(new GameObject("Prism"), parent);
            var prism = go.AddComponent<Prism>();
            prism.Init();
            return prism;
        }
    }
}
