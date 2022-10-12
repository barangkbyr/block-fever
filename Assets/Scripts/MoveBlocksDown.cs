using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocksDown : MonoBehaviour {
    public Vector2 newGridPos;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float step;

    public void GoDownTest() {
        step = speed * Time.deltaTime;

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, newGridPos, step);
    }
}
