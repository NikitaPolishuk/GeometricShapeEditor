using Assets.Scripts.Contollers;
using System.Collections.Generic;
using UnityEngine;


public class ParallelepipedMeshGenerator : MeshShapeGenerator
{
    private PolyhedronSideFaceGenerator _sideFaceGenerator;

    public ParallelepipedMeshGenerator()
    {
        _sideFaceGenerator = new PolyhedronSideFaceGenerator();
    }

    public Mesh GetGenerateMesh(float length, float width, float height)
    {
        CreateMeshData(length, width, height);
        return BuildMesh();
    }

    private void CreateMeshData(float length, float width, float height)
    {
        _vertices = new List<Vector3> { new Vector3(0f, 0f, 0), new Vector3(width, 0f, 0), new Vector3(width, 0f, length), new Vector3(0f, 0f, length) };
        _triangles = new List<int> { 0, 1, 2, 2, 3, 0 };

        var verticesCount = _vertices.Count;
        for (int i = 0; i < verticesCount; i++)
        {
            _vertices.Add(_vertices[i] + new Vector3(0, height, 0));
        }

        var trianglesCount = _triangles.Count;
        for (int i = 0; i < trianglesCount; i++)
        {
            _triangles.Add(_triangles[(trianglesCount - 1) - i] + 4);
        }

        _triangles.AddRange(_sideFaceGenerator.Generatå(4));

        _mesh = new Mesh();
    }
}
