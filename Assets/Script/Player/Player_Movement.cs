using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    Animator player_anim;
    [SerializeField]
    GameObject LevelComplete_Panel;
    float horizontalInput, verticalInput;
    float speed = 7.0f;
    public float rotationSpeed;

    private void Start()
    {
        Time.timeScale = 1;
        player_anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput > 0 || horizontalInput < 0 || verticalInput > 0 || verticalInput < 0)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            moveDirection.Normalize();

            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
            player_anim.SetFloat("Speed_f", 0.2f);
            player_anim.SetBool("Static_b", true);
            
            
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            player_anim.SetFloat("Speed_f", 0.0f);
        }
    }

    public void LevelComplete()
    {
        StartCoroutine(PlayerCelebrate());
    }

    IEnumerator PlayerCelebrate()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex;
        player_anim.SetInteger("Animation_int", 10);
        LevelComplete_Panel.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(nextScene + 1);
    }
}
