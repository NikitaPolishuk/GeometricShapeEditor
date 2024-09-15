using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPrismCreator : MonoBehaviour
{
    public float height = 2f; // ������ ������
    public int sides = 6; // ���������� ������� ������
    public float radius = 1f; // ������ ��������� ���������� ���������

    private MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = CreatePrism();
    }

    Mesh CreatePrism()
    {
        Mesh mesh = new Mesh();

        // ���������� ������: ������� � ������ ���������, ���� ���� ������� � ������ ������� ���������
        int vertexCount = sides * 2 + 2;
        Vector3[] vertices = new Vector3[vertexCount];

        // ������� � ������ ��������� ������
        for (int i = 0; i < sides; i++)
        {
            float angle = 2 * Mathf.PI * i / sides;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            // ������� �������
            vertices[i] = new Vector3(x, height / 2, z);
            // ������ �������
            vertices[i + sides] = new Vector3(x, -height / 2, z);
        }

        // ����������� ����� �������� � ������� ���������
        vertices[vertexCount - 2] = new Vector3(0, height / 2, 0);   // ����� �������� ���������
        vertices[vertexCount - 1] = new Vector3(0, -height / 2, 0);  // ����� ������� ���������

        // ����������� �������������
        int[] triangles = new int[sides * 12]; // 6 ������������� �� ����� (2 �� ���������, 4 �� ������� �����)
        int t = 0;

        // ������� �����
        for (int i = 0; i < sides; i++)
        {
            int nextIndex = (i + 1) % sides;

            // ������ ����������� ������� ����� (������� �� ������� �������)
            triangles[t++] = i;
            triangles[t++] = nextIndex;
            triangles[t++] = i + sides;

            // ������ ����������� ������� ����� (������� �� ������� �������)
            triangles[t++] = nextIndex;
            triangles[t++] = nextIndex + sides;
            triangles[t++] = i + sides;
        }

        // ������� ��������� (�������� ������� ������, ����� ��� ���� ����� �������)
        for (int i = 0; i < sides; i++)
        {
            int nextIndex = (i + 1) % sides;
            // ������� ������ ������ ������� �������
            triangles[t++] = vertexCount - 2; // ����������� ����� �������� ���������
            triangles[t++] = nextIndex;
            triangles[t++] = i;
        }

        // ������ ��������� (���������� ������� ������, ����� ��� ���� ����� �������)
        for (int i = 0; i < sides; i++)
        {
            int nextIndex = (i + 1) % sides;
            // ������� ������ �� ������� �������
            triangles[t++] = vertexCount - 1; // ����������� ����� ������� ���������
            triangles[t++] = i + sides;
            triangles[t++] = nextIndex + sides;
        }


        // ���������� ������ � ����
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}