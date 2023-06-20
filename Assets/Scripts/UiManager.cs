using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;
    public Canvas gameCanvas;

    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
    }

    public void CharacterTookDamage(GameObject character, int damageTake)
    {
        Vector2 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(damageTextPrefab, spawnPosition ,Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = damageTake.ToString();
    }

    private void OnEnable()
    {
        CharacterEvent.characterDamaged += (CharacterTookDamage);
        CharacterEvent.characterHealed += (CharacterHealed);
    }
    private void OnDisable()
    {
        CharacterEvent.characterDamaged -= (CharacterTookDamage);
        CharacterEvent.characterHealed -= (CharacterHealed);
    }


    public void CharacterHealed(GameObject character, int healthHealed)
    {
        Vector2 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);

        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = healthHealed.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
