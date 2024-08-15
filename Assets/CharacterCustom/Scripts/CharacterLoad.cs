using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject existingCharacter; // Reference to the existing character in the scene

    private void Start()
    {
        if (CharacterManager.Instance.CurrentCharacter != null)
        {
            // Destroy the existing character model
            if (existingCharacter != null)
            {
                Destroy(existingCharacter);
            }

            // Instantiate the selected character
            GameObject newCharacter = Instantiate(CharacterManager.Instance.CurrentCharacter);

            // Set the parent to spawn point
            newCharacter.transform.SetParent(spawnPoint, false);

            // Reset position and rotation
            newCharacter.transform.localPosition = Vector3.zero;
            newCharacter.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }
}
