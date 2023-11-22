using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NN.Utilities;
public class Spider : MonoBehaviour
{

    private Vector2 dir;
    private Vector2 dir1;
    private float currentAngle = 90;
    private float destinationAngle;

    public SpiderLeg legPrefab;
    private List<SpiderLeg> legs = new List<SpiderLeg>();
    private void Update()
    {
        dir1 = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) dir1 = Vector3.left;
        if (Input.GetKey(KeyCode.D)) dir1 = Vector3.right;
        if (Input.GetKey(KeyCode.W)) dir1 = Vector3.up;
        if (Input.GetKey(KeyCode.S)) dir1 = Vector3.down;

        currentAngle += 1f;

        dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * currentAngle), Mathf.Sin(Mathf.Deg2Rad * currentAngle));
        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
        if (Input.GetMouseButton(0))
        {
            transform.position += (Vector3)dir * 5 * Time.deltaTime;
        }

        //transform.position += (Vector3)dir1 * 10 * Time.deltaTime;
        CreateLeg((List<Point>)EventDispatcher.Call(ScriptName.Spanwer, Events.GetNearPonts, transform.position + transform.right, 3f));


    }

    private void CreateLeg(List<Point> destinations)
    {
        int pointsCount = legs.Count;

        foreach (var a in ((List<Point>)EventDispatcher.Call(ScriptName.Spanwer, Events.GetPoints))) a.UnHighlight();
        foreach (var a in destinations) a.Highlight();

        for (int i = 0; i < Mathf.Max(destinations.Count, pointsCount); i++)
        {
            if (i >= destinations.Count)
            {
                legs[i].gameObject.SetActive(false);
            }
            else if (i >= legs.Count)
            {
                legs.Add(Instantiate(legPrefab, transform));
                legs[i].Draw(transform.position, destinations[i].transform.position, dir);
            }
            else
            {
                legs[i].gameObject.SetActive(true);
                legs[i].Draw(transform.position, destinations[i].transform.position, dir);
            }
        }
    }
}
