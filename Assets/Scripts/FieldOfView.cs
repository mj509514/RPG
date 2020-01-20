using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    public float fov = 90;
    public float viewDistance = 50;
    private Vector3 origin;
    private float startingAngle;


    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        //fov = 90f;
        //viewDistance = 50f;
        origin = Vector3.zero;
    }

    internal void SetAimDirection()
    {
        throw new NotImplementedException();
    }

    private void LateUpdate()
    {

        
        //Vector3 origin = Vector3.zero;
        int rayCount = 40;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
   


        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex /*= origin + GetVectorFromAngle(angle) * viewDistance */ ;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                //no hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //hit object
                vertex = raycastHit2D.point;
            }

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;


        }

       /* vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        */

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public void SetOrigin(Vector3 Origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirecition)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirecition) - fov / 2f;
    }


    public void SetFoV(float fov)
    {
        this.fov = fov;
    }

    public void SetViewDistance (float viewDistance)
    {
        this.viewDistance = viewDistance;
    }




}


