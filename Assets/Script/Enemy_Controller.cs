using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject Game_Over_Panel;
    public Transform[] wayPoints;
    int current_Point;
    public float speed = 5.0f;
    public float rotationSpeed;
    public float rangeUnits;

    private void Start()
    {
        current_Point = 0;
    }

    private void FixedUpdate()
    {
       Enemy_Rotation_Movement();
       Player_Detection();
    }

    void Enemy_Rotation_Movement()
    {
        if (wayPoints.Length > 0)
        {
            if (transform.position != wayPoints[current_Point].position)
            {
                Vector3 targetRotation = wayPoints[current_Point].position - transform.position;
                Quaternion lookAtRotation = Quaternion.LookRotation(targetRotation, Vector3.up);

                transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, rotationSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, wayPoints[current_Point].position, speed * Time.deltaTime);
            }
            else
            {
                current_Point = (current_Point + 1) % wayPoints.Length;
            }
        }
    }

    void Player_Detection()
    {
        
        RaycastHit ray;
         
        Vector3 Direction = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, Direction, out ray, rangeUnits))
        {
            if (ray.collider.CompareTag("Player"))
            {
                Time.timeScale = 0;
                Game_Over_Panel.SetActive(true);
            }    
        }   
    }
}
