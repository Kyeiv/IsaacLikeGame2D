using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpriteSelector : MonoBehaviour {
	
	public Sprite 	spU, spD, spR, spL,
			spUD, spRL, spUR, spUL, spDR, spDL,
			spULD, spRUL, spDRU, spLDR, spUDRL;
	public bool up, down, left, right;
	public int type; // 0: normal, 1: enter
	public Color normalColor, enterColor;
	Color mainColor;
	SpriteRenderer rend;
	void Start () {
		rend = GetComponent<SpriteRenderer>();
        rend.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
        rend.transform.position += new Vector3(135f, 60f, 0);

		mainColor = normalColor;
		PickSprite();
		PickColor();
	}
	void PickSprite(){ //picks correct sprite based on the four door bools
		if (up){
			if (down){
				if (right){
					if (left){
						rend.sprite = spUDRL;
					}else{
						rend.sprite = spDRU;
					}
				}else if (left){
					rend.sprite = spULD;
				}else{
					rend.sprite = spUD;
				}
			}else{
				if (right){
					if (left){
						rend.sprite = spRUL;
					}else{
						rend.sprite = spUR;
					}
				}else if (left){
					rend.sprite = spUL;
				}else{
					rend.sprite = spU;
				}
			}
			return;
		}
		if (down){
			if (right){
				if(left){
					rend.sprite = spLDR;
				}else{
					rend.sprite = spDR;
				}
			}else if (left){
				rend.sprite = spDL;
			}else{
				rend.sprite = spD;
			}
			return;
		}
		if (right){
			if (left){
				rend.sprite = spRL;
			}else{
				rend.sprite = spR;
			}
		}else{
			rend.sprite = spL;
		}
	}

	void PickColor(){ //changes color based on what type the room is
		if (type == 0){
			mainColor = normalColor;
		}else if (type == 1){
			mainColor = enterColor;
            GameObject pos = GameObject.FindGameObjectWithTag("pos");
            Vector3 positionWorld = new Vector3(rend.transform.position.x , rend.transform.position.y , pos.transform.position.z) ;
            RectTransform rect = pos.GetComponent<RectTransform>();
            Camera mycam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            rect.position =  mycam.WorldToScreenPoint(positionWorld);

        }
        mainColor.a=0.2f;
		rend.color = mainColor;
	}
}