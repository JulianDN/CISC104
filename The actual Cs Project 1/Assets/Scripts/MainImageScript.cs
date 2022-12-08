using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainImageScript : MonoBehaviour
{
    [SerializeField] private GameObject image_unkown;
    [SerializeField] private GameControllerScript gameController;
    
    public void OnMouseDown()
    {
        if (image_unkown.activeSelf && gameController.canOpen)
            
        {
            image_unkown.SetActive(false);
            gameController.imageOpened(this);
        }
    }
    private int _spriteId;

    public int spriteId
    {
        get { return _spriteId; }
    }


    public void ChangeSprite(int id, Sprite image)
    {

        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
   
    public void Close()
    {
        image_unkown.SetActive(true);
    }
}