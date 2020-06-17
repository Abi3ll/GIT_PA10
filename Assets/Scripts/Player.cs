using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public int speed = 3;
    public float force = 300;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector2.right * speed;
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            GetComponent<Rigidbody>().AddForce(Vector2.up * force);
        }
           
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
