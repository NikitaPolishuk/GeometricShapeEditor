using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTriangleGenerator
{
    public List<int> Generatå(int sectors)
    {
        var triangles = new List<int>();
        for (int i = 0; i < sectors; i++)
        {
            for (int j = 0; j < sectors; j++)
            {
                int first = i * (sectors + 1) + j;
                int second = first + sectors + 1;
                triangles.Add(first);
                triangles.Add(first + 1);
                triangles.Add(second);

                triangles.Add(second);
                triangles.Add(first + 1);
                triangles.Add(second + 1);
            }
        }

        return triangles;
    }
}
