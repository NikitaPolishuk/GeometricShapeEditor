using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contollers
{
    public class CapsuleMeshGenerator : MeshShapeGenerator
    {

        private void CreateMeshData(float radius, int sectors, float height)
        {
            GenerateVertices(radius, sectors, height);
            MakeTriangles(sectors);
           _mesh = new Mesh();
        }

        private void GenerateVertices(float radius, int sectors, float height)
        {
            _vertices = new List<Vector3>();

            float halfHeight = height / 2;

            for (int i = 0; i <= sectors; i++)
            {
                float angle = Mathf.PI * i / sectors / 2;
                for (int j = 0; j <= sectors; j++)
                {
                    float theta = 2 * Mathf.PI * j / sectors;
                    float x = radius * Mathf.Sin(angle) * Mathf.Cos(theta);
                    float y = radius * Mathf.Cos(angle) + halfHeight;
                    float z = radius * Mathf.Sin(angle) * Mathf.Sin(theta);
                    _vertices.Add(new Vector3(x, y, z));
                }
            }

            for (int i = 0; i <= sectors; i++)
            {
                float y = halfHeight - (i * height / sectors);
                for (int j = 0; j <= sectors; j++)
                {
                    float theta = 2 * Mathf.PI * j / sectors;
                    float x = radius * Mathf.Cos(theta);
                    float z = radius * Mathf.Sin(theta);
                    _vertices.Add(new Vector3(x, y, z));
                }
            }


            for (int i = 0; i <= sectors; i++)
            {
                float angle = Mathf.PI * i / sectors / 2;
                for (int j = 0; j <= sectors; j++)
                {
                    float theta = 2 * Mathf.PI * j / sectors;
                    float x = radius * Mathf.Sin(angle) * Mathf.Cos(theta);
                    float y = -radius * Mathf.Cos(angle) - halfHeight;
                    float z = radius * Mathf.Sin(angle) * Mathf.Sin(theta);
                    _vertices.Add(new Vector3(x, y, z));
                }
            }
        }

        private void MakeTriangles(int sectors)
        {
            _triangles = new List<int>();

            for (int i = 0; i < sectors; i++)
            {
                for (int j = 0; j < sectors; j++)
                {
                    int first = i * (sectors + 1) + j;
                    int second = first + sectors + 1;

                    _triangles.Add(first);
                    _triangles.Add(first + 1);
                    _triangles.Add(second);

                    _triangles.Add(second);
                    _triangles.Add(first + 1);
                    _triangles.Add(second + 1);
                }
            }

            int offset = (sectors + 1) * (sectors + 1);
            for (int i = 0; i < sectors; i++)
            {
                for (int j = 0; j < sectors; j++)
                {
                    int first = offset + i * (sectors + 1) + j;
                    int second = first + sectors + 1;

                    _triangles.Add(first);
                    _triangles.Add(first + 1);
                    _triangles.Add(second);

                    _triangles.Add(second);
                    _triangles.Add(first + 1);
                    _triangles.Add(second + 1);
                }
            }

            int sphereOffset = 2 * offset;
            for (int i = 0; i < sectors; i++)
            {
                for (int j = 0; j < sectors; j++)
                {
                    int first = sphereOffset + i * (sectors + 1) + j;
                    int second = first + sectors + 1;

                    _triangles.Add(first);
                    _triangles.Add(second);
                    _triangles.Add(first + 1);

                    _triangles.Add(second);
                    _triangles.Add(second + 1);
                    _triangles.Add(first + 1);
                }
            }
        }

        public Mesh GetGenerateMesh(float radius, int sectors, float height)
        {
            CreateMeshData(radius, sectors, height);
            return BuildMesh();
        }
    }
}