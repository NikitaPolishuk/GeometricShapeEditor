using Assets.Scripts.Interfaces;
using Assets.Scripts.Model;
using UnityEngine;
namespace Asset.Scripts.Factory
{
    public class ParallelepipedFactory : IShapeFactory
    {
        public IShape CreateShape(Transform parent)
        {
            var go = GameObject.Instantiate(new GameObject("Parallelepiped"), parent);
            var prism = go.AddComponent<Parallelepiped>();
            prism.Init();
            return prism;
        }
    }
}
