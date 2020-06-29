using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private Collider2D dPadCollider;
    private bool isClicked;
    private PlayerMovement playerMovement;
    void Start()
    {
        isClicked = false;
        dPadCollider = GetComponent<Collider2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        mouseMove();
        TouchMove();
    }
    private void mouseMove(){
        Vector2 touchPosition =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
        if(Input.GetMouseButton(0) && dPadCollider == touchedCollider){
            Color tmp = this.GetComponent<SpriteRenderer>().color;
            tmp.a = .4f;
            this.GetComponent<SpriteRenderer>().color = tmp;
            
            if(this.gameObject.tag == "Button1"){
                playerMovement.LightUp();
            }
            else if(this.gameObject.tag == "ButtonUp"){
                playerMovement.MoveUp();
            }
            else if(this.gameObject.tag == "ButtonDown"){
                playerMovement.MoveDown();
            }
            else if(this.gameObject.tag == "ButtonLeft"){
                playerMovement.MoveLeft();
            }
            else if(this.gameObject.tag == "ButtonRight"){
                playerMovement.MoveRight();
            }
        }else{
            Color tmp = this.GetComponent<SpriteRenderer>().color;
            tmp.a = .05f;
            this.GetComponent<SpriteRenderer>().color = tmp;
            isClicked = false;
        }
        if(Input.GetMouseButtonUp(0)){
            Color tmp = this.GetComponent<SpriteRenderer>().color;
            tmp.a = .05f;
            this.GetComponent<SpriteRenderer>().color = tmp;
            isClicked = false;
        }
    }
    private void TouchMove(){
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition =  Camera.main.ScreenToWorldPoint(touch.position);
            Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
            if(touch.phase == TouchPhase.Moved && dPadCollider == touchedCollider){
                Color tmp = this.GetComponent<SpriteRenderer>().color;
                tmp.a = .4f;
                this.GetComponent<SpriteRenderer>().color = tmp;
                if(this.gameObject.tag == "Button1"){
                    playerMovement.LightUp();
                }
                else if(this.gameObject.tag == "ButtonUp"){
                    playerMovement.MoveUp();
                }
                else if(this.gameObject.tag == "ButtonDown"){
                    playerMovement.MoveDown();
                }
                else if(this.gameObject.tag == "ButtonLeft"){
                    playerMovement.MoveLeft();
                }
                else if(this.gameObject.tag == "ButtonRight"){
                    playerMovement.MoveRight();
                }
            }
            if(touch.phase == TouchPhase.Ended){
                Color tmp = this.GetComponent<SpriteRenderer>().color;
                tmp.a = .05f;
                this.GetComponent<SpriteRenderer>().color = tmp;
                isClicked = false;
            }
        }
    }
}
