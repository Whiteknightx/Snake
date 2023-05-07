using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    [SerializeField] private float speed;
    [SerializeField] private float val;

    private List<Transform> _segments;

    public Transform segmentPrefab;

    private void Start()
    {
        _segments = new List<Transform>
        {
            this.transform
        };
    }
    private void Update()
 {
    if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
    {
        _direction = Vector2.up;
    }
    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
    {
        _direction = Vector2.down;
    }
    else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    {
        _direction = Vector2.right;
    }
    else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
        _direction = Vector2.left;
    }
 }
    private void FixedUpdate()
    {
        print(this.transform.position.y);
        this.transform.position = new Vector3
            (
             (this.transform.position.x) + (_direction.x),
             this.transform.position.y + (_direction.y),
            0.0f
            );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.transform.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
            Grow();
    }
}
