

public interface IHealth 
{
    void TakeDamage(float damage);

}
public interface IController
{
    float FORCE { get; }
    float TURN { get; }
    float JUMPFOCE { get; }
    float WALK_ANIM { get; }
    float TURN_ANIM { get; }
    bool ATTACK { get; }
    void ForceChanger(float change);
    void TurnChanger(float change);
    void AnimChangeFloat(float animChange);
    void TurnAnimChangeFloat(float turnChange);
    void AnimAttack(bool isattack);
 }
internal interface IAnimatedController
{
    float MOVEFORCE { get; }
    float TURNFORCE { get; }
    bool ISPUNCH { get; }
    void Move(float Mforce);
    void Turn(float Tforce);
    void Punch(bool isPunch);

}
internal interface IPhysicHitReact
{
    bool ISHIT { get; }
    void Hit(bool isHt);
}
internal interface IAi
{
    bool ISMOVE { get; }
    float RAYDIST { get; }
    void RayDistCount(float rayDist);
    void Move(bool isMove);
}
public interface IgroundCheck
{ 
    bool ISGOUNDED { get; }
    void IsGrounded(bool isGrounded);
}



