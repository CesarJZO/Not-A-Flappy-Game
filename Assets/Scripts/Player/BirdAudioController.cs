using Player;
using UnityEngine;

public sealed class BirdAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip jumpAudioClip;

    private void Start()
    {
        BirdController.Instance.OnJump += OnBirdJump;
    }

    private void OnDestroy()
    {
        BirdController.Instance.OnJump -= OnBirdJump;
    }

    private void OnBirdJump()
    {
        AudioManager.Instance.PlayVariablePitch(jumpAudioClip);
    }
}
