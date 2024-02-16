using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.zero;
    }

    // Update is called once per frame

    public float speed = 10f; // Adjust the speed as needed

    // Update is called once per frame
    void Update()
    {
        // Move the object forward based on its own forward direction
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector3.back;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector3.forward;
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entered collider is the one you want to trigger the direction change
        if (other.CompareTag("Coin"))
        {
            score++;
            //Debug.Log(score);
            StartCoroutine(DeactivateForSeconds(2,other));
            
        }
    }
    private System.Collections.IEnumerator DeactivateForSeconds(float seconds,Collider collider)
    {
        collider.gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        collider.gameObject.SetActive(true);
    }

}
