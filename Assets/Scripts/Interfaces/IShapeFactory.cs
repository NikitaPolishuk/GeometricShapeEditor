
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IShapeFactory
    {
        IShape CreateShape(Transform parent);
    }
}
