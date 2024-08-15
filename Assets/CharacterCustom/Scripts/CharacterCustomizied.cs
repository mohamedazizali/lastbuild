using UnityEngine;

public class CharacterCustomizied : MonoBehaviour
{
    public enum CharacterPart
    {
        Shirt,
        Pants,
        Shoes,
        Hair
    }

    [SerializeField] private GameObject Tshirt;
    [SerializeField] private GameObject Pants;
    [SerializeField] private GameObject Shoes;
    [SerializeField] private GameObject Hair1;
    [SerializeField] private GameObject Hair2;

    [SerializeField] private Material[] shirtMaterials;
    [SerializeField] private Material[] pantsMaterials;
    [SerializeField] private Material[] shoesMaterials;
    [SerializeField] private Material[] hairMaterialsForHair1;
    [SerializeField] private Material[] hairMaterialsForHair2;

    private Material currentShirtMaterial;
    private Material currentPantsMaterial;
    private Material currentShoesMaterial;
    private Material currentHairMaterialForHair1;
    private Material currentHairMaterialForHair2;

    void Start()
    {
        InitializeMaterials();
        LoadCustomization();
    }

    private void InitializeMaterials()
    {
        if (Tshirt != null)
        {
            currentShirtMaterial = Tshirt.GetComponent<Renderer>().sharedMaterial;
        }
        if (Pants != null)
        {
            currentPantsMaterial = Pants.GetComponent<Renderer>().sharedMaterial;
        }
        if (Shoes != null)
        {
            currentShoesMaterial = Shoes.GetComponent<Renderer>().sharedMaterial;
        }
        if (Hair1 != null)
        {
            Renderer hairRenderer1 = Hair1.GetComponent<Renderer>();
            if (hairRenderer1 != null)
            {
                currentHairMaterialForHair1 = hairRenderer1.sharedMaterial;
            }
        }
        if (Hair2 != null)
        {
            Renderer hairRenderer2 = Hair2.GetComponent<Renderer>();
            if (hairRenderer2 != null)
            {
                currentHairMaterialForHair2 = hairRenderer2.sharedMaterial;
            }
        }
    }

    public void ChangeColor(CharacterPart part)
    {
        switch (part)
        {
            case CharacterPart.Shirt:
                ChangeShirtColor();
                break;
            case CharacterPart.Pants:
                ChangePantsColor();
                break;
            case CharacterPart.Shoes:
                ChangeShoesColor();
                break;
            case CharacterPart.Hair:
                ChangeHairColor();
                break;
        }
    }

    public void ChangeColorToPrevious(CharacterPart part)
    {
        switch (part)
        {
            case CharacterPart.Shirt:
                ChangeShirtColorToPrevious();
                break;
            case CharacterPart.Pants:
                ChangePantsColorToPrevious();
                break;
            case CharacterPart.Shoes:
                ChangeShoesColorToPrevious();
                break;
            case CharacterPart.Hair:
                ChangeHairColorToPrevious();
                break;
        }
    }

    private void ChangeShirtColor()
    {
        int matIndex = FindMaterialIndex(currentShirtMaterial, shirtMaterials);
        if (matIndex != -1)
        {
            currentShirtMaterial = shirtMaterials[(matIndex + 1) % shirtMaterials.Length];
            Tshirt.GetComponent<Renderer>().sharedMaterial = currentShirtMaterial;
        }
    }

    private void ChangeShirtColorToPrevious()
    {
        int matIndex = FindMaterialIndex(currentShirtMaterial, shirtMaterials);
        if (matIndex != -1)
        {
            currentShirtMaterial = shirtMaterials[(matIndex - 1 + shirtMaterials.Length) % shirtMaterials.Length];
            Tshirt.GetComponent<Renderer>().sharedMaterial = currentShirtMaterial;
        }
    }

    private void ChangePantsColor()
    {
        int matIndex = FindMaterialIndex(currentPantsMaterial, pantsMaterials);
        if (matIndex != -1)
        {
            currentPantsMaterial = pantsMaterials[(matIndex + 1) % pantsMaterials.Length];
            Pants.GetComponent<Renderer>().sharedMaterial = currentPantsMaterial;
        }
    }

    private void ChangePantsColorToPrevious()
    {
        int matIndex = FindMaterialIndex(currentPantsMaterial, pantsMaterials);
        if (matIndex != -1)
        {
            currentPantsMaterial = pantsMaterials[(matIndex - 1 + pantsMaterials.Length) % pantsMaterials.Length];
            Pants.GetComponent<Renderer>().sharedMaterial = currentPantsMaterial;
        }
    }

    private void ChangeShoesColor()
    {
        int matIndex = FindMaterialIndex(currentShoesMaterial, shoesMaterials);
        if (matIndex != -1)
        {
            currentShoesMaterial = shoesMaterials[(matIndex + 1) % shoesMaterials.Length];
            Shoes.GetComponent<Renderer>().sharedMaterial = currentShoesMaterial;
        }
    }

    private void ChangeShoesColorToPrevious()
    {
        int matIndex = FindMaterialIndex(currentShoesMaterial, shoesMaterials);
        if (matIndex != -1)
        {
            currentShoesMaterial = shoesMaterials[(matIndex - 1 + shoesMaterials.Length) % shoesMaterials.Length];
            Shoes.GetComponent<Renderer>().sharedMaterial = currentShoesMaterial;
        }
    }

    private void ChangeHairColor()
    {
        int matIndexForHair1 = FindMaterialIndex(currentHairMaterialForHair1, hairMaterialsForHair1);
        int matIndexForHair2 = FindMaterialIndex(currentHairMaterialForHair2, hairMaterialsForHair2);

        if (matIndexForHair1 != -1)
        {
            Material newHairMaterialForHair1 = hairMaterialsForHair1[(matIndexForHair1 + 1) % hairMaterialsForHair1.Length];
            if (Hair1 != null)
            {
                Renderer hairRenderer1 = Hair1.GetComponent<Renderer>();
                if (hairRenderer1 != null)
                {
                    hairRenderer1.sharedMaterial = newHairMaterialForHair1;
                }
            }
            currentHairMaterialForHair1 = newHairMaterialForHair1;
        }

        if (matIndexForHair2 != -1)
        {
            Material newHairMaterialForHair2 = hairMaterialsForHair2[(matIndexForHair2 + 1) % hairMaterialsForHair2.Length];
            if (Hair2 != null)
            {
                Renderer hairRenderer2 = Hair2.GetComponent<Renderer>();
                if (hairRenderer2 != null)
                {
                    hairRenderer2.sharedMaterial = newHairMaterialForHair2;
                }
            }
            currentHairMaterialForHair2 = newHairMaterialForHair2;
        }
    }

    private void ChangeHairColorToPrevious()
    {
        int matIndexForHair1 = FindMaterialIndex(currentHairMaterialForHair1, hairMaterialsForHair1);
        int matIndexForHair2 = FindMaterialIndex(currentHairMaterialForHair2, hairMaterialsForHair2);

        if (matIndexForHair1 != -1)
        {
            Material newHairMaterialForHair1 = hairMaterialsForHair1[(matIndexForHair1 - 1 + hairMaterialsForHair1.Length) % hairMaterialsForHair1.Length];
            if (Hair1 != null)
            {
                Renderer hairRenderer1 = Hair1.GetComponent<Renderer>();
                if (hairRenderer1 != null)
                {
                    hairRenderer1.sharedMaterial = newHairMaterialForHair1;
                }
            }
            currentHairMaterialForHair1 = newHairMaterialForHair1;
        }

        if (matIndexForHair2 != -1)
        {
            Material newHairMaterialForHair2 = hairMaterialsForHair2[(matIndexForHair2 - 1 + hairMaterialsForHair2.Length) % hairMaterialsForHair2.Length];
            if (Hair2 != null)
            {
                Renderer hairRenderer2 = Hair2.GetComponent<Renderer>();
                if (hairRenderer2 != null)
                {
                    hairRenderer2.sharedMaterial = newHairMaterialForHair2;
                }
            }
            currentHairMaterialForHair2 = newHairMaterialForHair2;
        }
    }

    public void SaveCustomization()
    {
        PlayerPrefs.SetInt("ShirtMaterialIndex", System.Array.IndexOf(shirtMaterials, currentShirtMaterial));
        PlayerPrefs.SetInt("PantsMaterialIndex", System.Array.IndexOf(pantsMaterials, currentPantsMaterial));
        PlayerPrefs.SetInt("ShoesMaterialIndex", System.Array.IndexOf(shoesMaterials, currentShoesMaterial));
        PlayerPrefs.SetInt("Hair1MaterialIndex", System.Array.IndexOf(hairMaterialsForHair1, currentHairMaterialForHair1));
        PlayerPrefs.SetInt("Hair2MaterialIndex", System.Array.IndexOf(hairMaterialsForHair2, currentHairMaterialForHair2));
    }

    public void LoadCustomization()
    {
        int shirtIndex = PlayerPrefs.GetInt("ShirtMaterialIndex", 0);
        int pantsIndex = PlayerPrefs.GetInt("PantsMaterialIndex", 0);
        int shoesIndex = PlayerPrefs.GetInt("ShoesMaterialIndex", 0);
        int hair1Index = PlayerPrefs.GetInt("Hair1MaterialIndex", 0);
        int hair2Index = PlayerPrefs.GetInt("Hair2MaterialIndex", 0);

        currentShirtMaterial = shirtMaterials[shirtIndex];
        currentPantsMaterial = pantsMaterials[pantsIndex];
        currentShoesMaterial = shoesMaterials[shoesIndex];
        currentHairMaterialForHair1 = hairMaterialsForHair1[hair1Index];
        currentHairMaterialForHair2 = hairMaterialsForHair2[hair2Index];

        Tshirt.GetComponent<Renderer>().sharedMaterial = currentShirtMaterial;
        Pants.GetComponent<Renderer>().sharedMaterial = currentPantsMaterial;
        Shoes.GetComponent<Renderer>().sharedMaterial = currentShoesMaterial;
        Hair1.GetComponent<Renderer>().sharedMaterial = currentHairMaterialForHair1;
        Hair2.GetComponent<Renderer>().sharedMaterial = currentHairMaterialForHair2;
    }

    private int FindMaterialIndex(Material currentMaterial, Material[] materialArray)
    {
        for (int i = 0; i < materialArray.Length; i++)
        {
            if (materialArray[i] == currentMaterial)
            {
                return i;
            }
        }
        return -1;
    }
}
