using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolaIgraca : MonoBehaviour {

    private float xmin, xmax;

    public float brzina = 15.0f;        
    public float brzinaProjektila;
    public float snaga = 250f;

    public GameObject projektil;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x;
        xmax = krajnjedesno.x;
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * brzina * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * brzina * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {


            Vector3 offset = transform.position;
            offset.y += 1f;
            GameObject laser = Instantiate(projektil, offset, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, brzinaProjektila,0);
        }


        // ograničavanje kretanja Svemirskog broda izvan scene
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

	}





    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projektil missle = collision.gameObject.GetComponent<Projektil>();
        if (missle)
        {
            snaga -= missle.GetDamange();
            missle.Hit();
            if(snaga <= 0)
            {
                Die();
                Debug.Log("Crko");
            }

        }
    }



    void Die()
    {
        LevelMenager man = GameObject.Find("LevelManager").GetComponent<LevelMenager>();
        man.Loadlevel("Lose");
        Destroy(gameObject);
    }
}
