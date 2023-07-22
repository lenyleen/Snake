using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    
    public BoxCollider2D boxcol;
    void Start()
    {
        RandomisePos();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "OFF" | other.tag == "InWall" )
        {
        RandomisePos();
        }
    }
    private void RandomisePos()
    {
        Bounds bounds = this.boxcol.bounds;
        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
        this.transform.position = new Vector3(x,y, 0.0f);
    }
}
