
using UnityEngine;
using UnityEngine.U2D;

public  class SetSprite : MonoBehaviour
{


    [SerializeField] private bool SetSpriteWhenLoadingScene;
    [SerializeField] private SpriteAtlas spriteAtlas;
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private string nameSprite;

    

    private void Awake()

    {

        if (SetSpriteWhenLoadingScene)
        {
            ChangeSprite();
        }
      
    }

    
    
    public void ChangeSprite()
    {
        SpriteRenderer spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = spriteAtlas.GetSprite(nameSprite);
    }

}
