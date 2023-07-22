using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InWallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform inWall;
    
    public BoxCollider2D borders;
    private List<Transform> inWalls;
    
    private bool once = true;
    CircleCollider2D wallsCol;
    
    int countInt;
    void Start()
    {
        inWalls = new List<Transform>();
        for(int i = 0; i < 4; i++ )
        {
            
            
            inWalls.Add(inWall);
            Instantiate(inWalls[i].gameObject);
            RandomPos(inWalls[i]);
            
        }
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
       if(SnakeMove.count == 450 & once)
       {
            inWalls.Add(inWall);
            Instantiate(inWalls[inWalls.Count-1].gameObject);
            RandomPos(inWalls[inWalls.Count-1]);
            once = false;
       }
        
    }
    private void RandomPos(Transform trans)
    {    
         
        Bounds bound = this.borders.bounds;
        float x = Mathf.Round(Random.Range(bound.min.x, bound.max.x));
        float y = Mathf.Round(Random.Range(bound.min.y, bound.max.y));
       
        trans.position = new Vector3(x,y,0.0f);
         if(trans.position.y >= 13)
        {
         trans.Rotate(new Vector3(0.0f, 0.0f, 270f));   
        }
        else if(y <= -14)
        {
        trans.Rotate(new Vector3(0.0f, 0.0f, 90f));   
        }
        else if (trans.position.x  > 19)
        {
            trans.Rotate(new Vector3(0.0f, 0.0f, 180f));
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Suchka" ) 
        {
            RandomPos(other.transform);
        }
        
    }
}
