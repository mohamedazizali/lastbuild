using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomUI : MonoBehaviour
{
    [SerializeField] private Button ShirtColorButton;
    [SerializeField] private Button PantsColorButton;
    [SerializeField] private Button ShoesColorButton;
    [SerializeField] private Button HairColorButton;

    [SerializeField] private Button ShirtColorPreviousButton;
    [SerializeField] private Button PantsColorPreviousButton;
    [SerializeField] private Button ShoesColorPreviousButton;
    [SerializeField] private Button HairColorPreviousButton;
    [SerializeField] private Button SaveButton; // New Save Button
    [SerializeField] private CharacterCustomizied characterCustomizer;

    private void Update()
    {
        characterCustomizer = GameObject.FindWithTag("Player")?.GetComponent<CharacterCustomizied>();
    }
    private void Awake()
    {
        ShirtColorButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColor(CharacterCustomizied.CharacterPart.Shirt);
        });

        PantsColorButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColor(CharacterCustomizied.CharacterPart.Pants);
        });

        ShoesColorButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColor(CharacterCustomizied.CharacterPart.Shoes);
        });

        HairColorButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColor(CharacterCustomizied.CharacterPart.Hair);
        });

        ShirtColorPreviousButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColorToPrevious(CharacterCustomizied.CharacterPart.Shirt);
        });

        PantsColorPreviousButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColorToPrevious(CharacterCustomizied.CharacterPart.Pants);
        });

        ShoesColorPreviousButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColorToPrevious(CharacterCustomizied.CharacterPart.Shoes);
        });

        HairColorPreviousButton.onClick.AddListener(() =>
        {
            characterCustomizer.ChangeColorToPrevious(CharacterCustomizied.CharacterPart.Hair);
        });
        SaveButton.onClick.AddListener(() =>
        {
            characterCustomizer.SaveCustomization();
            // Optionally: Load the next scene
            //SceneManager.LoadScene(3); // Replace with your scene name
           
        });
    }
}
