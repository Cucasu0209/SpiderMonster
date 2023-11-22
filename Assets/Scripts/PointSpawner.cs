using NN.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PointSpawner : MonoBehaviour
{
    public Point DotPrefab;
    private List<Point> points = new List<Point>();

    private void Awake()
    {
        EventDispatcher.Addlistener<int>(ScriptName.Spanwer, Events.RespawnPoint, SpawnPointsOverScreen);
        EventDispatcher.Register(ScriptName.Spanwer, Events.GetPoints, GetPoins);
        EventDispatcher.Register<Vector3, float, List<Point>>(ScriptName.Spanwer, Events.GetNearPonts, GetNearPoints);

    }
    private void Start()
    {
        SpawnPointsOverScreen(0);
    }
    private List<Vector2> GetPointPos(Vector2 center, Vector2 size, int count = 200)
    {
        List<Vector2> result = new List<Vector2>();
        float minX = center.x - size.x / 2;
        float maxX = center.x + size.x / 2;
        float minY = center.y - size.y / 2;
        float maxY = center.y + size.y / 2;


        for (int i = 0; i < count; i++)
        {
            result.Add(new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)));
        }

        return result;
    }
    private List<Vector2> GetPointPosinGrid(Vector2 center, Vector2 size)
    {
        List<Vector2> result = new List<Vector2>();
        float minX = center.x - size.x / 2;
        float maxX = center.x + size.x / 2;
        float minY = center.y - size.y / 2;
        float maxY = center.y + size.y / 2;


        for (int i = 0; i < (maxX - minX) / 0.5f; i++)
        {
            for (int j = 0; j < (maxY - minY) / 0.5f; j++)
            {
                result.Add(new Vector2(minX + i * 0.5f, minY + j * 0.5f));
            }
        }

        return result;
    }

    public void SpawnPointsOverScreen(int index)
    {
        if (index == 0)
        {
            List<Vector2> positions = GetPointPos(Camera.main.transform.position, (Camera.main.transform.position - Camera.main.ScreenToWorldPoint(Vector3.zero)) * 2.4f, 200);
            Spawn(positions);
        }
        if (index == 1)
        {
            List<Vector2> positions = GetPointPosinGrid(Camera.main.transform.position, (Camera.main.transform.position - Camera.main.ScreenToWorldPoint(Vector3.zero)) * 2.4f);
            Spawn(positions);
        }
    }


    public void Spawn(List<Vector2> positions)
    {
        int pointsCount = points.Count;
        for (int i = 0; i < Mathf.Max(positions.Count, pointsCount); i++)
        {
            if (i >= positions.Count)
            {
                points[i].gameObject.SetActive(false);
            }
            else if (i >= points.Count)
            {
                points.Add(Instantiate(DotPrefab, positions[i], Quaternion.identity));
                points[i].transform.parent = GameObject.Find("Points").transform;
            }
            else
            {
                points[i].gameObject.SetActive(true);
                points[i].transform.position = positions[i];
            }
        }
    }

    private List<Point> GetPoins() => points.Where(p => p.gameObject.activeInHierarchy).ToList();

    private List<Point> GetNearPoints(Vector3 center, float distance)
    {
        return points.Where(p => p.gameObject.activeInHierarchy && Vector2.Distance(center, p.transform.position) < distance).ToList();
    }

}
