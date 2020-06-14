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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        spriteMask.transform.localScale = new Vector3(10f,10f,0);
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempVector = new Vector3(1.5f, 1.5f,0);
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetKey(KeyCode.Space)){
            spriteMask.transform.localScale += new Vector3(.002f,.002f,0);
            animator.SetBool("lightup", true);
            animator.SetBool("moving", false);
        }else if(spriteMask.transform.localScale.x > .9f || spriteMask.transform.localScale.y > .9f){
            spriteMask.transform.localScale -= new Vector3(.005f,.005f,0);
            animator.SetBool("lightup", false);
        }
        MoveAnimation();
        spriteMask.transform.position = this.transform.position;
        
    }
    private void MoveAnimation(){
        if(change != Vector3.zero && !animator.GetBool("lightup")){
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
}
