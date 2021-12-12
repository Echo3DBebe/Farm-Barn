using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject UIManager;
    Score_Controller SC;
    Rigidbody collectable_RB;
    public float speed = 2.0f;
    public float Yaxis = 15f;

    void Start()
    {
        SC = UIManager.GetComponent<Score_Controller>();
        collectable_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        collectable_RB.AddTorque(new Vector3(0, Yaxis, 0) * speed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Cookie") == true)
            {
                SC.UpdateCookieScore();
                Destroy(this.gameObject);
            }
            else
            {
                SC.UpdateBananaScore();
                Destroy(this.gameObject);
            } 
        }
    }
}
