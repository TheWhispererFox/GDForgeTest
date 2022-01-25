using UnityEngine;

public class TransitionController : MonoBehaviour
{
  private Animator _transitionAnimator;
  private LevelManager _levelManager;
  void Start()
  {
    _transitionAnimator = transform.GetComponent<Animator>();
    _levelManager = FindObjectOfType<LevelManager>();
  }
}
