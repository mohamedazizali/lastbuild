using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }

    public GameObject MaleCharacterPrefab;
    public GameObject FemaleCharacterPrefab;

    private GameObject currentCharacter;
    public GameObject CurrentCharacter => currentCharacter;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SelectCharacter(GameObject characterPrefab)
    {
        if (currentCharacter != null)
        {
            Destroy(currentCharacter);
        }
        currentCharacter = Instantiate(characterPrefab,gameObject.transform.position, gameObject.transform.rotation);
        DontDestroyOnLoad(currentCharacter);
    }
}
