using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Parallelepiped : Shape
    {
        private ParallelepipedMeshGenerator _parallelepipedMeshGenerator;

        public void Init()
        {
            _parallelepipedMeshGenerator = new ParallelepipedMeshGenerator();
            AddMeshRenderes();
        }

        public override void UpdateMesh(params object[] parameters)
        {
            float length;
            float width;
            float height;

            try
            {
                length = (float)parameters[0];
                width = (float)parameters[1];
                height = (float)parameters[2];
            }
            catch (System.Exception)
            {
                Debug.LogError("Incorrect mesh update parameters entered");
                throw;
            }

            var mesh = _parallelepipedMeshGenerator.GetGenerateMesh(length, width, height);
            _meshFilter.sharedMesh = mesh;
        }
    }
}
