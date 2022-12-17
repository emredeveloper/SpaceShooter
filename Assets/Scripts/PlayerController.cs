using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    AudioSource audioPlayer;
    public GameObject shotSpawn;
    [SerializeField] float NextFire;
    [SerializeField] float FireRate;
    Rigidbody fizik;
    [SerializeField] int speed;
    [SerializeField] int egim;
    public sinir sinirlama;
    // Start is called before the first frame update
    [System.Serializable]
    public class sinir
    {
        public float xMin, Xmax, Zmin, zMax;

    }
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerctialMove = Input.GetAxis("Vertical");
        Vector3 hareket = new Vector3 (HorizontalMove,0, VerctialMove);
        fizik.velocity = hareket * speed;
        Vector3 position = new Vector3(Mathf.Clamp(fizik.position.x, sinirlama.xMin, sinirlama.Xmax),0, Mathf.Clamp(fizik.position.z, sinirlama.Zmin, sinirlama.zMax));
        // math clamp sýnýrlama iþlemi yapar yani belirlediðimiz sýnýrlar dýþýna çýkamaz ve çýkaramayýz oyunda iken.
        fizik.position = position;


        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * egim); // gemimizin sað sola hareket ederken ona göre sað veya sola yatmasý kodu yani eðim.

    }
     void Update()
    {

        if (Input.GetButton("Fire1")&& Time.time>NextFire)
        {
            NextFire = Time.time + FireRate;
            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
            audioPlayer.Play();
        }
    }

}
