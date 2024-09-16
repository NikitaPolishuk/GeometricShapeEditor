using Assets.Scripts.Contollers;
using UnityEngine;
namespace Assets.Scripts.Model
{
    public class Capsule : Shape
    {
        private CapsuleMeshGenerator _capsuleMeshGenerator;

        public void Init()
        {
            _capsuleMeshGenerator = new CapsuleMeshGenerator();
            AddMeshRenderes();
        }

        public override void UpdateMesh(params object[] parameters)
        {
            float radius;
            int sectors;
            float height;

            try
            {
                radius = (float)parameters[0];
                sectors = (int)parameters[1];
                height = (float)parameters[2];
            }
            catch (System.Exception)
            {
                Debug.LogError("Incorrect mesh update parameters entered");
                throw;
            }

            var mesh = _capsuleMeshGenerator.GetGenerateMesh(radius, sectors, height);
            _meshFilter.sharedMesh = mesh;
        }
    }
}
