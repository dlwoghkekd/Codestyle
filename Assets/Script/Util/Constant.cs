
using UnityEngine;

public class Constant
{
    public static readonly int TRIGGER_START = Animator.StringToHash("Start");
    
    public static readonly int TRIGGER_END = Animator.StringToHash("End");

    public const float GROUND_INTERVAL = 3.36f;

    public const float OBSTACLE_POS_Y_MIN = 4f;

    public const float SPAWN_TMR = 1f;

    public const string FORM_SCORE = "<sprite={0}>";

    public const float FORCE_MULTIPLY = 8f;

    public const float OBJECT_MOVE_SPEED = 3f;

    public const string TAG_PLAYER = "Player";

    public const float PIPE_CENTER_INTERVAL = 2f;

    public const float PIPE_GOAL_HEIGHT_MIN = 2f;
    public const float PIPE_GOAL_HEIGHT_MAX = 5f;
}
