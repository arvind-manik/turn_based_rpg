using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    private bool isMoving;

    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Restricts diagonal movement
            if (input.x != 0) input.y = 0;

            //If input has a value, start a coroutine       
            if (input != Vector2.zero) {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
            Debug.Log(isMoving + " " + targetPos + transform.position);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
