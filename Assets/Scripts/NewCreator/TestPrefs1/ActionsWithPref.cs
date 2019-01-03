using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsWithPref : MonoBehaviour
{
    private Vector3 BufPosition;
    private Camera cam;
    private Camera cammain;
    private CameraMove cammove;
    public bool isDeleteble = true;
    public bool isDrag = false;
    public MapEditor BuildSwitcher;
    private Color sellected_color;
    private Color simple_color;

    [SerializeField]
    private MapEditor mapeditor;
    private Vector3 sub;
    private Renderer rend;
    private Rigidbody this_rig;
    private Vector3 stopped;
    private float move_speed = 40f;
    private float col_move_speed = 5f;
    private float uncol_move_speed = 40f;

    private void Awake()
    {

        cammain = Camera.main;
        cammove = cammain.GetComponent<CameraMove>();
        //cam = GameObject.FindGameObjectWithTag("raycastcam").GetComponent<Camera>();
        cam = Camera.main;
        mapeditor = GameObject.Find("Canvas").GetComponent<MapEditor>();
        BuildSwitcher = GameObject.Find("Scroll View").GetComponent<MapEditor>();
        sellected_color = new Color(0f,0.7f,0f);
        simple_color = new Color(1f, 1f, 1f);
        rend = this.GetComponent<Renderer>();
        this_rig = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        this.stopped = this.transform.position;
    }

    private void GetCurPos()
    {
        
        Vector3 m_pos;
        m_pos.x = Input.mousePosition.x;
        m_pos.y = Input.mousePosition.y;
        m_pos.z = cam.nearClipPlane;
        //print(m_pos);
        this.BufPosition = cam.ScreenToWorldPoint(m_pos);

        this.BufPosition.z = 0;
        //print(BufPosition);
    }



    private void MoveObject(GameObject go)
    {
        if(BuildSwitcher.CanMoveObjects)
        {
            GetCurPos();
            //this_rig.MovePosition(BufPosition - sub);
            //go.transform.position = BufPosition - sub;
            /*
            if (Mathf.Abs((BufPosition - sub).x - this.transform.position.x) > 0.7f ||
                Mathf.Abs((BufPosition - sub).y - this.transform.position.y) > 0.7f)
            {
                if ((BufPosition - sub).x < this.transform.position.x)
                    this.transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime * move_speed;
                else
                    this.transform.position += new Vector3(1f,0f,0f) * Time.deltaTime * move_speed;


                if ((BufPosition - sub).y < this.transform.position.y)
                    this.transform.position -= new Vector3(0f, 1f, 0f) * Time.deltaTime * move_speed;
                else
                    this.transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * move_speed;
            }
            */
            if (Mathf.Abs((BufPosition - sub).x - this.transform.position.x) > 0.3f ||
                Mathf.Abs((BufPosition - sub).y - this.transform.position.y) > 0.3f)
            {
                this.transform.position -= GetVectorDirecton(this.transform.position, BufPosition - sub) *
                          Time.deltaTime * move_speed;
            }

        }
    }

    private Vector3 GetVectorDirecton(Vector3 from_point, Vector3 to_point)
    {

        Vector3 v;

        v = GetDistanceVector(from_point, to_point);
        VectorNormalize(ref v);

        return v;
    }

    private void VectorNormalize(ref Vector3 v)
    {
        float len = Mathf.Sqrt(v.x * v.x + v.y * v.y + v.x * v.z);
        v.x /= len;
        v.y /= len;
        v.z /= len;
    }

    private Vector3 GetDistanceVector(Vector3 a, Vector3 b)
    {
        Vector3 v;

        v.x = a.x - b.x;
        v.y = a.y - b.y;
        v.z = a.z - b.z;

        return v;
    }

    private void OnMouseDown()
    {
        mapeditor.sellection = this.gameObject;
        GetCurPos();
        sub = GetDistanceVector(BufPosition, this.transform.position);
    }

    private void OnMouseDrag()
    {
        if (Time.timeScale != 0 && BuildSwitcher.CanMoveObjects)
        {
            MoveObject(this.gameObject);
            isDrag = true;
            cammove.CantMove();
        }
    }
    private void OnMouseUp()
    {
        isDrag = false;
        cammove.CanMove();
        stopped = this.transform.position;
    }

    private void Update()
    {
        if (!isDrag) this.transform.position = stopped;
        cam.nearClipPlane = -cam.transform.position.z - 4f;
    }
    private Vector3 col_pos;

    private void OnCollisionEnter(Collision collision)
    {
        col_pos = collision.transform.position;
        move_speed = col_move_speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (isDrag) collision.gameObject.GetComponent<Rigidbody>().MovePosition(col_pos);
                //collision.gameObject.transform.position = col_pos;
    }

    private void OnCollisionExit(Collision collision)
    {
        move_speed = uncol_move_speed;
    }
}
