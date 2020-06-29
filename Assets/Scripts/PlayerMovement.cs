using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Vector3 change;
    public float speed;
    private Rigidbody2D myRigidBody;
    public GameObject spriteMask;
    public GameObject lightSource;

    public bool isLightUp;
    // Start is called before the first frame update
    void Start()
    {
        isLightUp = false;
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        spriteMask.transform.localScale = new Vector3(1f,1f,0);
        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || isLightUp){
            spriteMask.transform.localScale += new Vector3(.003f,.003f,0);
            lightSource.transform.localScale += new Vector3(.003f,.003f,0);
            animator.SetBool("lightup", true);
            animator.SetBool("moving", false);
        }else if(spriteMask.transform.localScale.x > .9f || spriteMask.transform.localScale.y > .9f){
            spriteMask.transform.localScale -= new Vector3(.006f,.006f,0);
            lightSource.transform.localScale -= new Vector3(.006f,.006f,0);
            animator.SetBool("lightup", false);
        }
        MoveAnimation();
        spriteMask.transform.position = this.transform.position;
        lightSource.transform.position = this.transform.position;
        change = Vector3.zero;
        isLightUp = false;
    }
    private void MoveAnimation(){
        if(change != Vector3.zero && !animator.GetBool("lightup")){
            Debug.Log("change: "+change);
            MoveCharacter();
            if(change.x != 0){
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", 0);
            }else if(change.y != 0){
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", change.y);
            }
            animator.SetBool("moving", true);
        }else{
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter(){
        Vector3 changetemp = Vector3.zero;
        change.Normalize();
         if(change.x != 0){
            changetemp.x = change.x;
        }else if(change.y != 0){
            changetemp.y = change.y;
        }
        myRigidBody.MovePosition(transform.position + changetemp * speed * Time.deltaTime);
    }
    public void MoveUp(){
        change.y = 1f;
        change.x = 0f;
    }
        public void MoveDown(){
        change.y = -1f;
        change.x = 0f;
    }
    
    public void MoveLeft(){
        change.y = 0f;
        change.x = -1f;
    }
        public void MoveRight(){
        change.y = 0f;
        change.x = 1f;
    }
    public void LightUp(){
        isLightUp = true;
    }
}
