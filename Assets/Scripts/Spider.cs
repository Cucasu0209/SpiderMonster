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
    float lastimeDraw = 0;
    private void Update()
    {
        dir1 = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) { dir1 = Vector3.left; destinationAngle = 180; }
        else if (Input.GetKey(KeyCode.D)) { dir1 = Vector3.right; destinationAngle = 0; }
        else if (Input.GetKey(KeyCode.W)) { dir1 = Vector3.up; destinationAngle = 90; }
        else if (Input.GetKey(KeyCode.S)) { dir1 = Vector3.down; destinationAngle = 270; }

        if (dir1 != Vector2.zero)
        {
            currentAngle = ((currentAngle % 360) + 360) % 360;
            destinationAngle = ((destinationAngle - currentAngle) + 360) % 360;
            if (destinationAngle < 180)
                currentAngle += 1.3f;
            else currentAngle -= 1.3f;
        }

        dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * currentAngle), Mathf.Sin(Mathf.Deg2Rad * currentAngle));
        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);

        transform.position += (Vector3)dir1 * 5 * Time.deltaTime;


        CreateLeg((List<Point>)EventDispatcher.Call(ScriptName.Spanwer, Events.GetNearPonts, transform.position - transform.right, 2.5f));


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
