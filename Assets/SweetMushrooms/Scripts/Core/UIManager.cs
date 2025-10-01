using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameSessionManager _gameSessionManager;
    [SerializeField] private TextMeshProUGUI _counter;


    private void Update()
    {
        if (_gameSessionManager.CurrentMatchState != MatchState.Playing)
        {
            _counter.text = "0";
            return;
        }
        _counter.text = _gameSessionManager.TimeLeft.ToString();
    }
}
