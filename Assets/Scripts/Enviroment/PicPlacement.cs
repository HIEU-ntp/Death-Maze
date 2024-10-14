using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicPlacement : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject picPiece;

    public GameObject realWall;


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (GlobalInventory.rightPic == true && GlobalInventory.leftPic == true)
        {
            if (TheDistance <= 3)
            {
                ExtraCross.SetActive(true);
                ActionText.GetComponent<Text>().text = "Place pic pieces";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
            }
            if (Input.GetButtonDown("Action"))
            {
                if (TheDistance <= 3)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    ExtraCross.SetActive(false);
                    picPiece.SetActive(true);
                    realWall.GetComponent<Animator>().Play("RealWallAnim");
                }
            }
        }

        void OnMouseExit()
        {
            ExtraCross.SetActive(false);
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
    }
}