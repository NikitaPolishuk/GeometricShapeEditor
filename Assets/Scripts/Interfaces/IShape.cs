
namespace Assets.Scripts.Interfaces
{ 
    public interface IShape
    {
        void UpdateMesh(params object[] parameters);
        void Paint();
        void Destroy();
    }
}
