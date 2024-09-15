using Assets.Scripts.Contollers;
using Assets.Scripts.Interfaces;
using UnityEngine;


namespace Assets.Scripts.Model
{
    public abstract class Shape : MonoBehaviour, IShape
    {
        protected GameObject _shapeObject;
        protected MeshRenderer _meshRenderer;
        protected MeshFilter _meshFilter;
        protected MeshShapeGenerator _meshShapeGenerator;

        protected void AddMeshRenderes()
        {
            _meshRenderer = gameObject.AddComponent<MeshRenderer>();
            _meshFilter = gameObject.AddComponent<MeshFilter>();
        }


        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public void Paint()
        {
            throw new System.NotImplementedException();
        }

        public abstract void UpdateMesh(params object[] parameters);
    }
}
