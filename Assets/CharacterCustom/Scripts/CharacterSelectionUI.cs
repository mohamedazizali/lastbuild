using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionUI : MonoBehaviour
{
    public void SelectMaleCharacter()
    {
        CharacterManager.Instance.SelectCharacter(CharacterManager.Instance.MaleCharacterPrefab);
        //LoadCustomizationScene();
    }

    public void SelectFemaleCharacter()
    {
        CharacterManager.Instance.SelectCharacter(CharacterManager.Instance.FemaleCharacterPrefab);
        //LoadCustomizationScene();
    }

    private void LoadCustomizationScene()
    {
        SceneManager.LoadScene("3");
    }
}
