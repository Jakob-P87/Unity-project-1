using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCreator : MonoBehaviour
{
    public MeshFilter meshFilter;
    private NavMeshTriangulation triangulation;

    public Color walkableColor;
    public Color nonWalkableColor;
    public Color unknownColor;
    public Material material;

    private Mesh newMesh;
    
    void Start ()
    {
        newMesh = new Mesh();
        triangulation = NavMesh.CalculateTriangulation();

        newMesh.SetVertices(new List<Vector3>(triangulation.vertices));
        newMesh.SetIndices(triangulation.indices, MeshTopology.Triangles, 0);

        newMesh.RecalculateNormals();
        newMesh.RecalculateBounds();

        meshFilter.mesh = newMesh;
    }
}
