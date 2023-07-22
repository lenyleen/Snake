using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{
    public Text text;
    private Vector3 direction = Vector2.right;
    public float velocity = 0.05f;
    public Transform Tale;
    private List<Transform> Segments;
    private Vector3 startPos;
    private Vector3 normalSize;
    static  public int count;
    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
    }
    
    void Start()
    {
        startPos = this.transform.position;
        normalSize = new Vector3(0.75f, 0.75f, 1f);
        Segments = new List<Transform>();
        Segments.Add(this.transform);
    }

    
    private void FixedUpdate() 
    {
        for(int i = Segments.Count - 1; i > 0; i--)
        {
            Segments[i].position = Segments[i - 1].position;
        }
        this.transform.position = new Vector3 (
            Mathf.Round(this.transform.position.x + direction.x),
            Mathf.Round(this.transform.position.y + direction.y),
            0.0f
        ); 
        

    }
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.D))
        direction = Vector2.right;
        else if(Input.GetKeyDown(KeyCode.A))
        direction = Vector2.left;
        else if(Input.GetKeyDown(KeyCode.W))
        direction = Vector2.up;
        else if(Input.GetKeyDown(KeyCode.S))
        direction = Vector2.down;

        Debug.Log($"{-this.transform.position.x}");
        
        
    }
    private void Grow()
    {
       StartCoroutine(DelayOf());
     }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Food")
        {
        Grow();
        count+= 50;
        text.text = "Count:" + count;
        }
        else if(other.tag == "Wall")
        this.transform.position = new Vector3( this.transform.position.x,-this.transform.position.y, 0.0f);
        else if(other.tag == "SideWall")
        this.transform.position = new Vector3(-this.transform.position.x, this.transform.position.y, 0.0f);
        else if(other.tag == "Tale")
        {
            int n = 0;
            for(int i = Segments.IndexOf(other.gameObject.transform); i < Segments.Count; i++)
            {
                Destroy(Segments[i].gameObject);
                Segments.Remove(Segments[i]);
                n++;
            }
            count -= n*50;
            text.text = "Count:" + count;
        }    
        if(other.tag == "InWall")
        {
            foreach(Transform v in Segments)
            {
                Destroy(v.gameObject);
                
                
            }
        }
        
    }
    IEnumerator DelayOf()
    {
        for(int i = 0; i < Segments.Count; i++)
        {   
            if(i == 0)
            continue;
        Segments[i].localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(0.5f);
         Segments[i].localScale = normalSize;
        Debug.Log(",kzsd");
        }
        
        Transform _segments = Instantiate(this.Tale);
        _segments.position = Segments[Segments.Count - 1].position;
        Segments.Add(_segments);
    }
    private void Reastart()
    {
        
       
    }
}
