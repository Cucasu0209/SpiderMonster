using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLeg : MonoBehaviour
{
    public LineRenderer line;

    public void Draw(Vector2 start, Vector2 end, Vector2 dir)
    {

        float destination = Vector2.Distance(start, end);
        Vector2 dire = end - start;
        Vector2 dirR = new Vector2(-dire.y, dire.x);

        //test1
        Vector2 t1 = (start + (end - start) / 6) + dirR * destination / 12;
        Vector2 t2 = (start + (end - start) * 5 / 6) - dirR * destination / 6;

        //test2
        t1 = (start + (end - start) / 6) + dirR * destination / 7;
        t2 = end - dir.normalized * Mathf.Clamp(4 / (destination * destination), 0, destination * 2 / 3);

        t1 = start + dir * destination / 2;
        t2 = end - dir.normalized * Mathf.Clamp(6 / (destination * destination), 0, destination);

        t1 = start + ((end - start).normalized + dir.normalized).normalized * destination / 3;

        float PointCount = Mathf.RoundToInt(destination / 0.06f);
        Vector3[] point = new Vector3[(int)PointCount];
        for (int i = 1; i <= PointCount; i++)
        {
            Vector2 a = Vector2.Lerp(start, t1, i / PointCount);
            Vector2 b = Vector2.Lerp(t1, t2, i / PointCount);
            Vector2 c = Vector2.Lerp(t2, end, i / PointCount);
            Vector2 a1 = Vector2.Lerp(a, b, i / PointCount);
            Vector2 b1 = Vector2.Lerp(b, c, i / PointCount);
            Vector2 a2 = Vector2.Lerp(a1, b1, i / PointCount);
            //a = start * (PointCount - i) / PointCount + t1 * i / PointCount;
            //b = t1 * (PointCount - i) / PointCount + t2 * i / PointCount;
            //c = t2 * (PointCount - i) / PointCount + end * i / PointCount;

            //a1 = start * (PointCount - i) * (PointCount - i) / (PointCount * PointCount)
            //    + 2 * t1 * i * (PointCount - i) / (PointCount * PointCount)
            //    + t2 * i * i / (PointCount * PointCount);

            //b1 = t1 * (PointCount - i) * (PointCount - i) / (PointCount * PointCount)
            //   + 2 * t2 * i * (PointCount - i) / (PointCount * PointCount)
            //   + end * i * i / (PointCount * PointCount);

            point[i - 1] = a2;
            //point[i - 1] = (start * (PointCount - i) * (PointCount - i) / (PointCount * PointCount)
            //     + 2 * t1 * i * (PointCount - i) / (PointCount * PointCount)
            //     + t2 * i * i / (PointCount * PointCount)) * (PointCount - i) / PointCount
            //     + (t1 * (PointCount - i) * (PointCount - i) / (PointCount * PointCount)
            //    + 2 * t2 * i * (PointCount - i) / (PointCount * PointCount)
            //    + end * i * i / (PointCount * PointCount)) * i / PointCount;
        }
        line.positionCount = (int)PointCount;
        line.SetPositions(point);

    }


}
