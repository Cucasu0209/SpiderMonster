using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NN.Utilities;
public class Spider : MonoBehaviour
{
    private Vector2 fakeDir = Vector2.up;
    private Vector2 dir;
    public SpiderLeg legPrefab;
    private List<SpiderLeg> legs = new List<SpiderLeg>();
    private void Update()
    {
        dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) dir = Vector2.left;
        if (Input.GetKey(KeyCode.D)) dir = Vector2.right;
        if (Input.GetKey(KeyCode.S)) dir = Vector2.down;
        if (Input.GetKey(KeyCode.W)) dir = Vector2.up;
        //dir += (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * 5 * Time.deltaTime;

        transform.position += (Vector3)dir * 10 * Time.deltaTime;
        CreateLeg((List<Point>)EventDispatcher.Call(ScriptName.Spanwer, Events.GetNearPonts, transform.position, 3.4f));
    }

    private void CreateLeg(List<Point> destinations)
    {
        int pointsCount = legs.Count;
        for (int i = 0; i < Mathf.Max(destinations.Count, pointsCount); i++)
        {
            if (i >= destinations.Count)
            {
                legs[i].gameObject.SetActive(false);
            }
            else if (i >= legs.Count)
            {
                legs.Add(Instantiate(legPrefab, transform));
                legs[i].Draw(transform.position, destinations[i].transform.position, fakeDir);
            }
            else
            {
                legs[i].gameObject.SetActive(true);
                legs[i].Draw(transform.position, destinations[i].transform.position, fakeDir);
            }
        }
    }
}
