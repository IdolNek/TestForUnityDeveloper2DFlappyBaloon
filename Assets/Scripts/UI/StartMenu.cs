using TMPro;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject _startGameMenu;
    [SerializeField] private TMP_Dropdown _difficultSelect;
    [SerializeField] private GameEvent _gameEvent;
    public void StartGame()
    {
        _gameEvent.SetDifficult(_difficultSelect.value);
        _startGameMenu.SetActive(false);
    }
}
