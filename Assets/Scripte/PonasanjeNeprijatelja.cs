using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonasanjeNeprijatelja : MonoBehaviour {
    public float snaga = 150f;
    public float PucanjUSekundi = 0.1f;
    public float brzinaProjektila = 10f;
    public int rezultatValue = 150;
    private PrikazRezultata prikazRezultata;

    public GameObject projektil;

    private void Start()
    {
        prikazRezultata = GameObject.Find("Rezultat").GetComponent<PrikazRezultata>();
    }

    private void Update()
    {
        float vjerojatnos = PucanjUSekundi * Time.deltaTime;
        if(Random.value < vjerojatnos)
        {
            Fire();
        }
    }

    void Die()
    {
        prikazRezultata.Rezultat(rezultatValue);
        Destroy(gameObject);
    }

    void Fire()
    {
        Vector3 offset = new Vector3(0, -1.0f, 0);
        Vector3 polozajPucanja = transform.position + offset;
        GameObject missile = Instantiate(projektil, polozajPucanja, Quaternion.identity);
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -brzinaProjektila);        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projektil missle = collision.gameObject.GetComponent<Projektil>();
        if (missle)
        {
            missle.Hit();
            snaga -= missle.GetDamange();
            if(snaga <= 0)
            {
                Die();
            }
        }
    }
}
