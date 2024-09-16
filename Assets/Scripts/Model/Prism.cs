using Assets.Scripts.Contollers;
using System;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Prism : Shape
    {
        private PrismMeshGenerator _prismMeshGenerator;

        public void Init()
        {
            _prismMeshGenerator = new PrismMeshGenerator();
            AddMeshRenderes();
        }

        public override void UpdateMesh(params object[] parameters)
        {
            int verticesCount;
            float radius;
            float height;

            try
            {
                verticesCount = (int)parameters[0];
                radius = (float)parameters[1];
                height = (float)parameters[2];
            }
            catch (System.Exception)
            {
                Debug.LogError("Incorrect mesh update parameters entered");
                throw;
            }

            var mesh = _prismMeshGenerator.GetGenerateMesh(verticesCount, radius, height);
            _meshFilter.sharedMesh = mesh;
        }
    }
}
