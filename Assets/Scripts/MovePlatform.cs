using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField]
    [Range(0, 1)] private float offsetVar = 0;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float pingPong = Mathf.PingPong((Time.time + offsetVar) * moveSpeed, 1f);
        transform.position = startPosition + moveOffset * pingPong;
    }
}
