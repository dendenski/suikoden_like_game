using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GlowingEffect : MonoBehaviour
{
    public GameObject ground;
    public GameObject collision;
    public GameObject player;

    public float colorValue;
    public bool colorLightUp;
    // Start is called before the first frame update
    void Start()
    {
        colorValue = 0.1f;
        colorLightUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }
    private void ColorChange(){
        if(colorValue >= .8){
            colorLightUp = false;
        }else if(colorValue <= 0.15f){
            colorLightUp = true;
        }
        if(colorLightUp){
            colorValue += .001f;
        }else{
            colorValue -= .001f;
        }
        player.GetComponent<SpriteRenderer>().color = new Color(colorValue,colorValue,colorValue);
        ground.GetComponent<Tilemap>().color = new Color(colorValue,colorValue,colorValue);
        collision.GetComponent<Tilemap>().color = new Color(colorValue,colorValue,colorValue);
    }
}
