using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private List<Sprite> characters = new List<Sprite>();
    [SerializeField] private List<Sprite> backgrounds = new List<Sprite>();
    [SerializeField] private Image leftCharacter;
    [SerializeField] private Image rightCharacter;
    [SerializeField] private Image centerCharacter;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Animator textAnimator;
    [SerializeField] private TMP_Text dialogueBox;
    [SerializeField] private Button choicePrefab;
    [SerializeField] private GameObject choiceBox;
    [SerializeField] private DialogueManager dialogueManager;
    private int? currentSpriteLeft = null;
    private int? currentSpriteRight = null;
    private int? currentSpriteCenter = null;
    private int? currentSpriteBackground = null;
    // Start is called before the first frame update

    public void HandleActiveSprites(string spritePosition)
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

    public void ChangeCharacterSprite(int spriteId, string spritePosition)
    {
        if (spritePosition == "Left" && currentSpriteLeft != spriteId)
        {
            currentSpriteLeft = spriteId;
            leftCharacter.sprite = characters[spriteId];
        }
        else if (spritePosition == "Right" && currentSpriteRight != spriteId)
        {
            currentSpriteRight = spriteId;
            rightCharacter.sprite = characters[spriteId];
        }
        else if (spritePosition == "Center" && currentSpriteCenter != spriteId)
        {
            currentSpriteCenter = spriteId;
            centerCharacter.sprite = characters[spriteId];
        }
        else
        {
            return;
        }
    }

    public void ChangeBackgroundSprite(int backgroundId)
    {
        if (currentSpriteBackground != backgroundId)
        {
            currentSpriteBackground = backgroundId;
            backgroundImage.sprite = backgrounds[backgroundId];
        }
    }

    public IEnumerator LaunchNewTextCoroutine(string textToDisplay)
    {
        textAnimator.SetTrigger("fadeOut");
        yield return new WaitUntil(() => textAnimator.GetBool("coucou"));
        dialogueBox.text = textToDisplay;
        textAnimator.SetBool("coucou", false);
    }

    public void GenerateDialogueChoices(List<Answers> answers)
    {
        foreach (var answer in answers)
        {
            Button clone = Instantiate(choicePrefab);
            clone.transform.SetParent(choiceBox.transform);
            ChoiceComponent choiceComponent = clone.GetComponent<ChoiceComponent>();
            choiceComponent.choice.text = answer.answerText;
            choiceComponent.AnswerKarma = answer.answerKarma;
        }
    }

    public void HandleActiveChoice(bool isQuestion)
    {
        if (isQuestion)
        {
            choiceBox.SetActive(true);
        }
        else
        {
            choiceBox.SetActive(false);
        }
    }

    public void OnClickSaveButton()
    {
        GameManager.Instance.Save(dialogueManager.CurrentDialogue, dialogueManager.PlayerKarma);
    }
}
