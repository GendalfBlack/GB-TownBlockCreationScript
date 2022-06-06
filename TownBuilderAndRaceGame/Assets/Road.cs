using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Road : MonoBehaviour
{
    public GameObject road;
    public GameObject turn;
    public bool build_arround = false;
    public List<GameObject> blocks;

    private List<Vector3> last_vectors = new List<Vector3>();
    private List<GameObject> last_blocks = new List<GameObject>();

    private bool build_left = false;
    private bool build_right = false;
    private Vector3 place;
    private Vector3 rotation;
    private Vector3 direction = new Vector3(20, 0, 0);
    private Vector3 left = new Vector3(0, 0, -20);
    private Vector3 right = new Vector3(0, 0, 20);
    public void CreateRoad()
    {
        last_blocks.Clear();
        last_vectors.Clear();
        last_vectors.Add(place);
        last_vectors.Add(rotation);
        last_vectors.Add(direction);
        last_vectors.Add(left);
        last_vectors.Add(right);

        GameObject mem1 = Instantiate(road, place + transform.position + direction, Quaternion.Euler(rotation), gameObject.transform);
        place += direction;
        if (build_arround)
        {
            if (build_left)
            {
                GameObject surr1 = blocks[Random.Range(0, blocks.Count)];
                GameObject mem2 = Instantiate(surr1, place + transform.position + left, Quaternion.Euler(rotation), gameObject.transform);
                last_blocks.Add(mem2);
            }
            else
            {
                build_left = true;
            }
            if (build_right)
            {
                GameObject surr2 = blocks[Random.Range(0, blocks.Count)];
                GameObject mem3 = Instantiate(surr2, place + transform.position + right, Quaternion.Euler(rotation + new Vector3(0, 180, 0)), gameObject.transform);
                last_blocks.Add(mem3);
            }
            else
            {
                build_right = true;
            }
        }
        last_blocks.Add(mem1);
    }
    public void TurnLeft()
    {
        last_blocks.Clear();
        last_vectors.Clear();
        last_vectors.Add(place);
        last_vectors.Add(rotation);
        last_vectors.Add(direction);
        last_vectors.Add(left);
        last_vectors.Add(right);
        GameObject mem1 = Instantiate(turn, place + transform.position + direction, Quaternion.Euler(rotation), gameObject.transform);
        place += direction;
        direction = Quaternion.Euler(0, 90, 0) * direction;
        left = Quaternion.Euler(0, 90, 0) * left;
        right = Quaternion.Euler(0, 90, 0) * right;
        rotation = new Vector3(rotation.x, rotation.y + 90, rotation.z);
        last_blocks.Add(mem1);
        build_left = false;
    }
    public void TurnRight()
    {
        last_blocks.Clear();
        last_vectors.Clear();
        last_vectors.Add(place);
        last_vectors.Add(rotation);
        last_vectors.Add(direction);
        last_vectors.Add(left);
        last_vectors.Add(right);
        GameObject mem1 = Instantiate(turn, place + transform.position + direction, Quaternion.Euler(rotation + new Vector3(0, -270, 0)), gameObject.transform);
        place += direction;
        direction = Quaternion.Euler(0, -90, 0) * direction;
        left = Quaternion.Euler(0, -90, 0) * left;
        right = Quaternion.Euler(0, -90, 0) * right;
        rotation = new Vector3(rotation.x, rotation.y - 90, rotation.z);
        last_blocks.Add(mem1);
        build_right = false;
    }
    public void Back()
    {
        place = last_vectors[0];
        rotation = last_vectors[1];
        direction = last_vectors[2];
        left = last_vectors[3];
        right = last_vectors[4];
        foreach (GameObject go in last_blocks)
        {
            DestroyImmediate(go);
        }
    }
    public void Clear()
    {
        while (gameObject.transform.childCount > 0)
        {
            DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
        }
        place = new Vector3(0, 0, 0);
        rotation = new Vector3(0, 0, 0);
        direction = new Vector3(20, 0, 0);
        left = new Vector3(0, 0, -20);
        right = new Vector3(0, 0, 20);
    }
}

[CustomEditor(typeof(Road))]
public class RoadEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Road road = (Road)target;
        if (GUILayout.Button("Road"))
        {
            road.CreateRoad();
        }
        if (GUILayout.Button("TurnRight"))
        {
            road.TurnLeft();
        }
        if (GUILayout.Button("TurnLeft"))
        {
            road.TurnRight();
        }
        if (GUILayout.Button("Back"))
        {
            road.Back();
        }
        if (GUILayout.Button("Clear"))
        {
            road.Clear();
        }
    }
}