using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kontroller : MonoBehaviour
{
    public Button btn;
    private Rigidbody rb;
    public float hiz = 0.5f;
    public Text zaman, carpma, durum;
    float zamanSayaci = 0;
    bool oyunDevam = true;
    private int dusmanSayisi = 0;

    void Start()
    {
        durum.gameObject.SetActive(false);
        btn.gameObject.SetActive(false); 

        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if (oyunDevam)
        {
            zamanSayaci += Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Engel"))
        {
            GameOver();
        }
        else if (other.gameObject.CompareTag("Dusman"))
        {
            Destroy(other.gameObject);
            dusmanSayisi++;
            carpma.text = "Yok Ettiðiniz Terörist Sýðýnaklarýnýn Sayýsý: " + dusmanSayisi;
        }
    }

    void GameOver()
    {
        durum.gameObject.SetActive(true);
        durum.text = "Daða çarptýnýz! Oyun bitti!";
        durum.gameObject.SetActive(true);
        btn.gameObject.SetActive(true);
        oyunDevam = false;

    }
    void FixedUpdate()
    {
        if (oyunDevam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0,dikey );
            rb.AddForce(kuvvet * hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
