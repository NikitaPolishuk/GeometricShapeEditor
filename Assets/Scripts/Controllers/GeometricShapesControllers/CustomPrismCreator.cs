using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPrismCreator : MonoBehaviour
{
    public float height = 2f; // Высота призмы
    public int sides = 6; // Количество боковых граней
    public float radius = 1f; // Радиус описанной окружности основания

    private MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = CreatePrism();
    }

    Mesh CreatePrism()
    {
        Mesh mesh = new Mesh();

        // Количество вершин: верхнее и нижнее основание, плюс одна вершина в центре каждого основания
        int vertexCount = sides * 2 + 2;
        Vector3[] vertices = new Vector3[vertexCount];

        // Верхнее и нижнее основание призмы
        for (int i = 0; i < sides; i++)
        {
            float angle = 2 * Mathf.PI * i / sides;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            // Верхние вершины
            vertices[i] = new Vector3(x, height / 2, z);
            // Нижние вершины
            vertices[i + sides] = new Vector3(x, -height / 2, z);
        }

        // Центральная точка верхнего и нижнего основания
        vertices[vertexCount - 2] = new Vector3(0, height / 2, 0);   // центр верхнего основания
        vertices[vertexCount - 1] = new Vector3(0, -height / 2, 0);  // центр нижнего основания

        // Определение треугольников
        int[] triangles = new int[sides * 12]; // 6 треугольников на грань (2 на основание, 4 на боковую грань)
        int t = 0;

        // Боковые грани
        for (int i = 0; i < sides; i++)
        {
            int nextIndex = (i + 1) % sides;

            // Первый треугольник боковой грани (порядок по часовой стрелке)
            triangles[t++] = i;
            triangles[t++] = nextIndex;
            triangles[t++] = i + sides;

            // Второй треугольник боковой грани (порядок по часовой стрелке)
            triangles[t++] = nextIndex;
            triangles[t++] = nextIndex + sides;
            triangles[t++] = i + sides;
        }

        // Верхнее основание (обратный порядок обхода, чтобы оно было видно снаружи)
        for (int i = 0; i < sides; i++)
        {
            int nextIndex = (i + 1) % sides;
            // Порядок обхода против часовой стрелки
            triangles[t++] = vertexCount - 2; // Центральная точка верхнего основания
            triangles[t++] = nextIndex;
            triangles[t++] = i;
        }

        // Нижнее основание (правильный порядок обхода, чтобы оно было видно снаружи)
        for (int i = 0; i < sides; i++)
        {
            int nextIndex = (i + 1) % sides;
            // Порядок обхода по часовой стрелке
            triangles[t++] = vertexCount - 1; // Центральная точка нижнего основания
            triangles[t++] = i + sides;
            triangles[t++] = nextIndex + sides;
        }


        // Применение данных к мешу
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}