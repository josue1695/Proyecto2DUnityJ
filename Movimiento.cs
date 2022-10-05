using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public float x=0.05f;
    public float y=0.05f;
    public int puntos = 0;
    public int vidas = 3;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicio");
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            if(GetComponent<SpriteRenderer>().flipX == true){
                GetComponent<SpriteRenderer>().flipX = false;
            }
            transform.Translate(new Vector2((x*Time.deltaTime*10),0));
            anim.SetBool("Walk",true);
            anim.SetBool("Idle",false);
            anim.SetBool("Jump",false);
            anim.SetBool("Glide",false);
        }
        if(Input.GetKey(KeyCode.A)){
            if(GetComponent<SpriteRenderer>().flipX == false){
                GetComponent<SpriteRenderer>().flipX = true;
            }
            transform.Translate(new Vector2((-x*Time.deltaTime*10),0));
            anim.SetBool("Walk",true);
            anim.SetBool("Idle",false);
            anim.SetBool("Jump",false);
            anim.SetBool("Glide",false);

        }
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(new Vector2(0,(y*Time.deltaTime*10)));
            anim.SetBool("Walk",false);
            anim.SetBool("Idle",false);
            anim.SetBool("Jump",true);
            anim.SetBool("Glide",false);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(new Vector2(0,(-y*Time.deltaTime*10)));
            anim.SetBool("Walk",false);
            anim.SetBool("Idle",false);
            anim.SetBool("Jump",false);
            anim.SetBool("Glide",true);
        }
        /*
        if(Input.GetKey(KeyCode.Space)){
            if(GetComponent<RigidBody2D>().mass == 1){
                GetComponent<SpriteRenderer>().flipX == false;
            }
            transform.Translate(new Vector2(x*2,y));
            anim.SetBool("Walk",false);
            anim.SetBool("Idle",false);
            anim.SetBool("Jump",true);
        }*/
        
        if(Input.anyKey!=true){
            anim.SetBool("Walk",false);
            anim.SetBool("Idle",true);
            anim.SetBool("Jump",false);
            anim.SetBool("Glide",false);
        }
        if(transform.position.y <= -7.20f){
            if(PlayerPrefs.GetInt("checkpoint")==1){
                this.transform.position = new Vector2(-1.61f,-2.41f);
            }
            //SceneManager.LoadScene("GameOver");
        }
    }


    public void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag=="moneda"){
            puntos = puntos + 1;
            PlayerPrefs.SetInt("puntaje",puntos);
            Debug.Log("+1 punto");
            if(puntos==10){
                SceneManager.LoadScene("Mundo 2");
            }
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag=="Enemigo"){
            vidas = vidas - 1;
            Debug.Log("-1 Vida");
            if(vidas==0){
                SceneManager.LoadScene("GameOver");
            }
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag=="checkpoint"){
            PlayerPrefs.SetInt("checkpoint",1);
            Destroy(col.gameObject);
        }
    }

    /*public void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.tag=="moneda"){
            Debug.Log("1 punto");
            Destroy(col.gameObject);
        }
    }*/
    /*
    public void OnCollisionExit2D(Collision2D col) {
        if(col.gameObject.tag=="moneda"){
            Debug.Log("1 punto");
            Destroy(col.gameObject);
        }
    }*/

}
