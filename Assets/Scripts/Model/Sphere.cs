using Assets.Scripts.Contollers;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Sphere : Shape
    {
        private SphereMeshGenerator _prismMeshGenerator;

        private void Start()
        {
            Init();
            UpdateMesh(5f, 30);
        }

        public void Init()
        {
            _prismMeshGenerator = new SphereMeshGenerator();
            AddMeshRenderes();
        }

        public override void UpdateMesh(params object[] parameters)
        {
            float radius;
            int sectors;

            try
            {
                radius = (float)parameters[0];
                sectors = (int)parameters[1];
            }
            catch (System.Exception)
            {
                Debug.LogError("Incorrect mesh update parameters entered");
                throw;
            }

            var mesh = _prismMeshGenerator.GetGenerateMesh(radius, sectors);
            _meshFilter.sharedMesh = mesh;
        }
    }
}
