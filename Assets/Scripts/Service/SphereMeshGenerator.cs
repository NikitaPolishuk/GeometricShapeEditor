using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contollers
{
    public class SphereMeshGenerator : MeshShapeGenerator
    {
        private SphereTriangleGenerator _sphereTriangleGenerator;

        public SphereMeshGenerator()
        {
            _sphereTriangleGenerator = new SphereTriangleGenerator();
        }

        private void CreateMeshData(float radius, int sectors)
        {
            _vertices = new List<Vector3>();
            _triangles = new List<int>();

            float verticalStep = Mathf.PI * 2 / sectors;
            float horizontStep = Mathf.PI / sectors;

            for (int i = 0; i <= sectors; i++)
            {
                float stackAngle = Mathf.PI / 2 - i * horizontStep;
                float xz = radius * Mathf.Cos(stackAngle);
                float y = radius * Mathf.Sin(stackAngle);

                for (int j = 0; j <= sectors; j++)
                {
                    float sectorAngle = j * verticalStep;

                    float x = xz * Mathf.Cos(sectorAngle);
                    float z = xz * Mathf.Sin(sectorAngle);
                    _vertices.Add(new Vector3(x, y, z));
                }
            }

            _triangles.AddRange(_sphereTriangleGenerator.Generatå(sectors));

            _mesh = new Mesh();
        }

        public Mesh GetGenerateMesh(float radius, int sectors)
        {
            CreateMeshData(radius, sectors);
            return BuildMesh();
        }
    }
}
