using Assets.Scripts.Interfaces;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asset.Scripts.Factory
{
    public class CapsuleFactory : IShapeFactory
    {
        public IShape CreateShape(Transform parent)
        {
            var go = GameObject.Instantiate(new GameObject("Capsule"), parent);
            var prism = go.AddComponent<Capsule>();
            prism.Init();
            return prism;
        }
    }
}
