using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLeg : MonoBehaviour
{
    public LineRenderer line;


    public void Draw(Vector2 start, Vector2 end, Vector2 dir)
    {
        float destination = Vector2.Distance(start, end);
        dir = end - start;
        Vector2 dirR = new Vector2(-dir.y, dir.x);

        Vector2 t1 = (start + (end - start) / 6) + dirR * destination / 12;
        Vector2 t2 = (start + (end - start) * 5 / 6) - dirR * destination / 6;

        float PointCount = Mathf.RoundToInt(destination / 0.05f);
        string logst = "";
        Vector3[] point = new Vector3[(int)PointCount];
        for (int i = 1; i <= PointCount; i++)
        {
            Vector2 a = Vector2.Lerp(start, t1, i / PointCount);
            Vector2 b = Vector2.Lerp(t1, t2, i / PointCount);
            Vector2 c = Vector2.Lerp(t2, end, i / PointCount);
            Vector2 a1 = Vector2.Lerp(a, b, i / PointCount);
            Vector2 b1 = Vector2.Lerp(b, c, i / PointCount);
            Vector2 a2 = Vector2.Lerp(a1, b1, i / PointCount);
            logst += a + " " + b + c + a1 + b1 + a2 + "\n";
            point[i - 1] = a2;
        }
        Debug.Log(point.Length + " " + logst);
        line.positionCount = (int)PointCount;
        line.SetPositions(point);

    }


}
