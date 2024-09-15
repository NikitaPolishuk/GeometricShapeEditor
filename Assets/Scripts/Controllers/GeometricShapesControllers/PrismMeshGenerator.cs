using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contollers
{
    public class PrismMeshGenerator : MeshShapeGenerator
    {
        private PolyhedronSideFaceGenerator _sideFaceGenerator;

        public PrismMeshGenerator()
        {
            _sideFaceGenerator = new PolyhedronSideFaceGenerator();
        }

        public Mesh GetGenerateMesh(int verticesCount, float radius, float height)
        {
            CreateMeshData(verticesCount, radius, height);
            return BuildMesh();
        }


        private void CreateMeshData(int verticesCount, float radius, float height)
        {
            _vertices = new List<Vector3>();
            _triangles = new List<int>();

            var angle = 2 * Math.PI / verticesCount;
            for (int i = 0; i < verticesCount; i++)
            {
                var x = (float)Math.Cos(i * angle) * radius;
                var z = (float)Math.Sin(i * angle) * radius;
                _vertices.Add(new Vector3(x, 0, z));
            }

            for (int i = 0; i < verticesCount; i++)
            {
                _vertices.Add(_vertices[i] + new Vector3(0, height, 0));
            }

            _triangles.AddRange(_sideFaceGenerator.Generatå(verticesCount));

            var topCenter = new Vector3(0, height, 0);
            var botCenter = Vector3.zero;
            _vertices.Add(topCenter);
            _vertices.Add(botCenter);

            for (int i = 0; i < verticesCount; i++)
            {
                int nextIndex = (i + 1) % verticesCount;
                _triangles.Add(i);
                _triangles.Add(nextIndex);
                _triangles.Add(_vertices.Count - 1);

                _triangles.Add(nextIndex + verticesCount);
                _triangles.Add(i + verticesCount);
                _triangles.Add(_vertices.Count - 2);
            }
            _mesh = new Mesh();
        }
    }
}

