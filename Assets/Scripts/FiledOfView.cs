using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FiledOfView : MonoBehaviour
{

    private Mesh mesh;
    float fov;
    int rayCount;
    float viewDistance;
    float angle;
    float startingAngle;
    Vector3 origin;
    private LayerMask mask;

    public GameObject parent;

    public Ghost ghost;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = ghost.angle;
        viewDistance = ghost.range;

        setVisionOrigin(parent.transform.position.x, parent.transform.position.y);

        mask = LayerMask.GetMask("Collisions", "Player");
    }

    private void LateUpdate()
    {
        setVisionOrigin(parent.transform.position.x, parent.transform.position.y);

        rayCount = 50;
        angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit = Physics2D.Raycast(origin, VectorFromAngle(angle), viewDistance, mask);
            if(raycastHit.collider == null)
            {
                vertex = origin + VectorFromAngle(angle) * viewDistance;
            }
            else
            {
                if (raycastHit.transform.gameObject.tag == "Player")
                {
                    SceneManager.LoadScene("Death");
                }
                vertex = raycastHit.point;

            }

            vertices[vertexIndex] = vertex;

            if(i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);

    }

    public static Vector3 VectorFromAngle(float angle)
    {
        float rad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(rad), Mathf.Sin(rad));
    }

    public static float AngleFromVector(Vector3 direction)
    {
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle += 360;
        }

        return angle;
    }
    public void setVisionOrigin(float x, float y)
    {
        this.origin = new Vector3(x, y, -1);
    }

    public void setAim(Vector3 direction)
    {
        this.startingAngle = AngleFromVector(direction) + fov/2f;
    }
}