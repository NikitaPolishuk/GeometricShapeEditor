using Assets.Scripts.Contollers;

namespace Assets.Scripts.Model
{
    public class Parallelepiped : Shape
    {
        private ParallelepipedMeshGenerator _parallelepipedMeshGenerator;

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            _parallelepipedMeshGenerator = new ParallelepipedMeshGenerator();
            var mesh = _parallelepipedMeshGenerator.GetGenerateMesh(5, 6, 4);
            AddMeshRenderes();
        }

        public override void UpdateMesh(params object[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
