using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> characters = new List<Sprite>();
    [SerializeField] private List<Sprite> backgrounds = new List<Sprite>();
    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image rightCharacter;
    [SerializeField] private Image centerCharacter;
    [SerializeField] private Image backgroundImage;
    private int? currentSpriteLeft = null;
    private int? currentSpriteRight = null;
    private int? currentSpriteCenter = null;
    private int? currentSpriteBackground = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void HandleActiveSprites(string spritePosition)
    {
        if (spritePosition == "Left" && centerCharacter.gameObject.activeInHierarchy || 
            spritePosition == "Right" && centerCharacter.gameObject.activeInHierarchy)
        {
            leftCharacter.gameObject.SetActive(true);
            rightCharacter.gameObject.SetActive(true);
            centerCharacter.gameObject.SetActive(false);
        }
        else if (spritePosition == "Center" && !centerCharacter.gameObject.activeInHierarchy)
        {
            leftCharacter.gameObject.SetActive(false);
            rightCharacter.gameObject.SetActive(false);
            centerCharacter.gameObject.SetActive(true);
        }
    }

    private void ChangeCharacterSprite(int spriteId, string spritePosition)
    {
        if (spritePosition == "Left")
        {
            currentSpriteLeft = spriteId;
            leftCharacter.sprite = characters[spriteId];
        }
        else if (spritePosition == "Right")
        {
            currentSpriteRight = spriteId;
            rightCharacter.sprite = characters[spriteId];
        }
        else
        {
            currentSpriteCenter = spriteId;
            centerCharacter.sprite = characters[spriteId];
        }
    }

    private void ChangeBackgroundSprite(int backgroundId)
    {
        currentSpriteBackground = backgroundId;
        backgroundImage.sprite = backgrounds[backgroundId];
    }
    
}
