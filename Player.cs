using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBodyComponent;
    private Vector2 finishPosition = Vector2.zero;
    private bool _isSelected;

	public bool isSelected
	{
		get{ return _isSelected; }
	}

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    async void Update()
    {
        if(Input.GetMouseButton(0))
        {
            finishPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        var startPosition = rigidBodyComponent.position;
        rigidBodyComponent.velocity = (finishPosition - startPosition).normalized * 5;
        var a = startPosition - finishPosition;
        if(Mathf.Abs(a.x) < 0.01 
        && Mathf.Abs(a.y) < 0.01)
        {
            rigidBodyComponent.velocity = Vector2.zero;
        }
    }
}
