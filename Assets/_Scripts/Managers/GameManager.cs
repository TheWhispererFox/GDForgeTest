using System;
using UnityEngine;

/// <summary>
/// Nice, easy to understand enum-based game manager.
/// </summary>
public class GameManager : StaticInstance<GameManager>
{
  public static event Action<GameState> OnBeforeStateChanged;
  public static event Action<GameState> OnAfterStateChanged;

  public GameState State { get; private set; }

  // Kick the game off with the first state
  void Start() => ChangeState(GameState.Starting);

  public void ChangeState(GameState newState)
  {
    OnBeforeStateChanged?.Invoke(newState);

    State = newState;
    switch (newState)
    {
      case GameState.Starting:
        HandleStarting();
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    }

    OnAfterStateChanged?.Invoke(newState);

    Debug.Log($"New state: {newState}");
  }

  private void HandleStarting()
  {

  }
}

[Serializable]
public enum GameState
{
  Starting = 0
}