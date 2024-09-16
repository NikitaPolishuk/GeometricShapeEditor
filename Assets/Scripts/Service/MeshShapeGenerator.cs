using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Contollers
{
    public abstract class MeshShapeGenerator
    {
        protected List<Vector3> _vertices;
        protected List<int> _triangles;
        protected Mesh _mesh;

        protected  virtual Mesh BuildMesh()
        {
            _mesh.Clear();
            _mesh.vertices = _vertices.ToArray();
            _mesh.triangles = _triangles.ToArray();
            _mesh.RecalculateNormals();
            return _mesh;
        }
    }
}
