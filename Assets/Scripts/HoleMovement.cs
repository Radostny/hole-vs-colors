using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HoleMovement : MonoBehaviour
{
    [Header("Hole mesh")]
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshCollider meshCollider;

    [FormerlySerializedAs("moveLinits")]
    [Header("Hole verticies radius")]
    [SerializeField] private Vector2 moveLimits;
    [SerializeField] private float radius;
    [SerializeField] private Transform holeCenter;
    [Space]
    [SerializeField] private float moveSpeed;

    private Mesh mesh;
    private List<int> holeVerticies;
    private List<Vector3> offsets;
    private int holeVerticesCount;

    private float x, y;
    private Vector3 touch, targetPos;


    void Start()
    {
        Game.isMoving = false;
        Game.isGameover = false;
        
        holeVerticies = new List<int>();
        offsets = new List<Vector3>();

        mesh = meshFilter.mesh;

        FindHoleVerticies();
    }

    private void Update()
    {
        Game.isMoving = Input.GetMouseButton(0);
        if (!Game.isGameover && Game.isMoving)
        {
            //Move hole center
            MoveHole();
            //Update hole verticies
            UpdateHoleVerticiesPosition();
        }
    }

    void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touch = Vector3.Lerp(
            holeCenter.position,
            holeCenter.position + new Vector3(x, 0f, y),
            moveSpeed * Time.deltaTime
            );
        targetPos = new Vector3(
            Mathf.Clamp(touch.x, -moveLimits.x, moveLimits.x),
            touch.y,
            Mathf.Clamp(touch.z, -moveLimits.y, moveLimits.y));
        
        //holeCenter.position = touch;
        holeCenter.position = targetPos;
    }

    void UpdateHoleVerticiesPosition()
    {
        Vector3[] verticies = mesh.vertices;
        for (int i = 0; i < holeVerticesCount; i++)
        {
            verticies[holeVerticies[i]] = holeCenter.position + offsets[i];
        }
        //update mesh
        mesh.vertices = verticies;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    void FindHoleVerticies()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(holeCenter.position, mesh.vertices[i]);
            if (distance < radius)
            {
                holeVerticies.Add(i);
                offsets.Add(mesh.vertices[i] - holeCenter.position);
            }
        }

        holeVerticesCount = holeVerticies.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(holeCenter.position, radius);
    }
}
