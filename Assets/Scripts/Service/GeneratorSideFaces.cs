
using System.Collections.Generic;

namespace Assets.Scripts.Contollers
{
    public class PolyhedronSideFaceGenerator
    {
        public List<int> Generatå(int sides)
        {
            var triangles = new List<int>();
            for (int i = 0; i < sides; i++)
            {
                int nextIndex = (i + 1) % sides;

                triangles.Add(i + sides);
                triangles.Add(nextIndex);
                triangles.Add(i);

                triangles.Add(i + sides);
                triangles.Add(nextIndex + sides);
                triangles.Add(nextIndex);
            }

            return triangles;
        }
    }
}
