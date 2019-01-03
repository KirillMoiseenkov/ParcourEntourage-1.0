using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public delegate void TypeFunction();
[System.Serializable]
public class EventGeter : MonoBehaviour
{
    public Death death;
	public GameObject pointOfEdge;
    public GameObject character;
	private Vector3 Offset;
    private Vector3 startSlide;
    public float maxSlideSpeed;
    public float minSlideSpeed;
    public float SlideSpeed;
    public bool anima_is_play = false;
    public TypeFunction jump_method;
    public TypeFunction rotate_method;
    public bool danger = false;
    public Collider[] body = new Collider[12];
    public GameObject[] gos = new GameObject[12];
    private GameObject rot;
    public Collider col_rot;
	public string rota;
	public string bodu;
    public bool isSlide = false;
    private float k = 0.0f;
	public float dir = 1f;
    private Vector3 poss;
    private void Awake()
    {
		rot = GameObject.FindGameObjectWithTag(rota);
        gos = GameObject.FindGameObjectsWithTag(bodu);
        for (int i = 0; i < 11; i++)
            body[i] = gos[i].GetComponent<Collider>();
    }

    private void Update()
    {
        poss = new Vector3(this.transform.position.x,this.transform.position.y+4,this.transform.position.z);
       // Debug.DrawRay(poss, this.transform.forward, Color.red);//for debug trigger raycasts
        //Debug.DrawRay(this.transform.position, this.transform.up*4.5f,Color.red);//for debug trigger raycasts
        Offset.x = dir* Offset.x;
        if(isSlide)
        {
			Offset = pointOfEdge.transform.position - startSlide;
            if(SlideSpeed > minSlideSpeed)
				SlideSpeed -= Time.deltaTime;
            k += Time.deltaTime * SlideSpeed;
            character.transform.position = Vector3.Lerp(startSlide, 
				startSlide + Offset, k);
        }
        else
        {
            SlideSpeed = maxSlideSpeed;
            k = 0;
        }
    }

    public void Jump()
    {
        jump_method();
    }
    public void Rotate()
    {
        rotate_method();
    }
    public void AnimaBegin()
    {
        anima_is_play = true;
    }
    public void AnimaEnd()
    {
        anima_is_play = false;
    }
    public void IsDangerBegin()
    {
        danger = true;
        col_rot.enabled = false;
            for (int i = 0; i < 11; i++)
                body[i].enabled = true;
        //print("keke");
    }
    public void IsDangerEnd()
    {
        danger = false;
        col_rot.enabled = true;
        if(!death.isDeath)
            for (int i = 0; i < 11; i++)
                body[i].enabled = false;
        
    }
    public void StartSlide()
    {
        isSlide = true;
        startSlide = character.transform.position;
    }
    public void EndSlide()
    {
        isSlide = false;
    }
}

