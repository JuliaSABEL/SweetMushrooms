using UnityEngine;


public enum MatchState { Playing, Finished }

public class GameSessionManager : MonoBehaviour
{
    public MatchState CurrentMatchState { get; private set; } = MatchState.Playing;
    public int TimeLeft { get; private set; }
    
    [SerializeField] private GameSettings _gameSettings;

    private float _accum;


    private void Start()
    {
        TimeLeft = _gameSettings.matchDuration;
    }

    private void Update()
    {
        if(CurrentMatchState != MatchState.Playing) return;
        
        _accum += Time.deltaTime;

        if (_accum >= 1f)
        {
            TimeLeft--;
            _accum = 0f;

            if (TimeLeft <= 0)
            {
                TimeLeft = 0;
                
                FinishMatch();
            }
        }
    }
    
    private void FinishMatch()
    {
        Debug.Log("Время всё :(");
        CurrentMatchState = MatchState.Finished;
    }
}
