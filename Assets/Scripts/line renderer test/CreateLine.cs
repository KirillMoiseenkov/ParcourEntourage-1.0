using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class CreateLine : MonoBehaviour
{
    public float distance;

    private LineRenderer lineRenderer;
    private Vector3 point;
    private Vector3 buf_point;
    private Camera cam;
    private Camera line_renderer_cam;
    private int i = 0;

    public bool camera_move = false;
    public struct Patterns
    {
        public Vector3[] points;
    }
    public int pattern_count;
    public string condition;
    public Patterns front_flip_pattern;
    public bool it_debug_mode = false;
    public bool tester = false;
    public Vector3 start_point;
    public Vector3[] buf_pattern;
    public float error;
    public float percents = 0.25f;
    public float percent_counter = 0;

    private void Awake()
    {
        front_flip_pattern = new Patterns();
        front_flip_pattern.points = new Vector3[40];
        cam = Camera.main;
        line_renderer_cam = GameObject.Find("draw").GetComponent<Camera>();
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        if(camera_move)cam.transform.position += transform.right * 3f * Time.deltaTime;

        buf_point = line_renderer_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        buf_point.z = 0;

        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(point, buf_point) > distance)
            {
                point = line_renderer_cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                point.z = 0;
                if (i == 0) start_point = point;
                if(it_debug_mode)
                {
                    front_flip_pattern.points[i] = this.transform.InverseTransformPoint(point) - 
                        this.transform.InverseTransformPoint(start_point);
                    print(front_flip_pattern.points[i]);
                    start_point = point;
                }
                else
                {
                    buf_pattern[i] = this.transform.InverseTransformPoint(point) - 
                        this.transform.InverseTransformPoint(start_point);
                    start_point = point;
                }
                i++;
                lineRenderer.SetVertexCount(i);
                lineRenderer.SetPosition(i - 1, point);
            }
        }
        else
        {
            if (!it_debug_mode && tester)
            {
                for (int a = 0; a < 20; a++)
                {
                    print(Vector3.Distance(front_flip_pattern.points[a], buf_pattern[a]));
                    if (Vector3.Distance(front_flip_pattern.points[a], buf_pattern[a]) > error && percent_counter/10 > percents)
                    { condition = "pizdec!"; break; }
                    else { percent_counter += 1; condition = "zbs!"; }
                }
                percent_counter = 0;
                print(condition);
                tester = false;
            }
            i = 0;
            lineRenderer.SetVertexCount(0);
        }
    }
}
