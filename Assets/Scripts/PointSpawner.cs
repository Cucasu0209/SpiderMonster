using NN.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PointSpawner : MonoBehaviour
{
    public Point DotPrefab;
    private List<Point> points = new List<Point>();
    List<Point> CacheNearPoint = new List<Point>();
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

        float delta = 0.6f;
        for (int i = 0; i < (maxX - minX) / delta; i++)
        {
            for (int j = 0; j < (maxY - minY) / delta; j++)
            {
                result.Add(new Vector2(minX + i * delta, minY + j * delta));
            }
        }

        return result;
    }

    public void SpawnPointsOverScreen(int index)
    {
        if (index == 0)
        {
            List<Vector2> positions = GetPointPos(Camera.main.transform.position, (Camera.main.transform.position - Camera.main.ScreenToWorldPoint(Vector3.zero)) * 2.4f, 250);
            Spawn1(positions);
        }
        if (index == 1)
        {
            List<Vector2> positions = GetPointPosinGrid(Camera.main.transform.position, (Camera.main.transform.position - Camera.main.ScreenToWorldPoint(Vector3.zero)) * 2.4f);
            Spawn1(positions);
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

    public void Spawn1(List<Vector2> positions)
    {
        foreach (var point in points)
        {
            Destroy(point.gameObject);
        }

        points.Clear();
        foreach (var pos in positions)
        {
            Point a = Instantiate(DotPrefab, pos, Quaternion.identity);
            points.Add(a);
            a.transform.parent = GameObject.Find("Points").transform;
        }
    }

    private List<Point> GetPoins()
    {
        return points;
    }


    float lastTimeGetNearPoints = -10;
    private List<Point> GetNearPoints(Vector3 center, float distance)
    {
        //if (Time.time - lastTimeGetNearPoints > 0.1f)
        //{
        //    lastTimeGetNearPoints = Time.time;
        CacheNearPoint.Clear();
        foreach (var point in points)
        {
            if (Vector2.Distance(center, point.transform.position) < distance && point.gameObject.activeInHierarchy)
                CacheNearPoint.Add(point);
        }
        //}

        return CacheNearPoint;
        //return points.Where(p => p.gameObject.activeInHierarchy && Vector2.Distance(center, p.transform.position) < distance).ToList();
    }
    private void Update()
    {

    }
}
