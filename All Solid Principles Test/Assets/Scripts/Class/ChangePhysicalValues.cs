using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePhysicalValues : MonoBehaviour
{
    protected float[] rbMass;
    protected float[] rbDrag;
    [SerializeField] protected Rigidbody[] rb;
    [SerializeField][Range(0.0f,5000.0f)] protected float[] changeMassUp;
    [SerializeField] [Range(0.0f, 5000.0f)] protected float[] changeMassDown;
    [SerializeField] [Range(0.0f, 5000.0f)] protected float[] changeDragUp;
    [SerializeField] [Range(0.0f, 5000.0f)] protected float[] changeDragDown;
    [SerializeField]protected Collider leftLeg;
    [SerializeField]protected Collider rightLeg;
    [SerializeField]protected PhysicMaterial _defaulFriction;
    [SerializeField] protected PhysicMaterial _zeroFriction;
    private void Awake()
    {
        rbDrag = new float[rb.Length];
        rbMass = new float[rb.Length];
        MassDown();
    }
    public void MassUp()
    {
        for (int i = 0; i < changeMassUp.LongLength; i++)
        {
            rbMass[i] = changeMassUp[i];
            rbDrag[i] = changeDragUp[i];
        }
    }
    public void MassDown()
    {
        for (int i = 0; i < changeMassDown.LongLength; i++)
        {
            rbMass[i] = changeMassDown[i];
            rbDrag[i] = changeDragDown[i];
        }
    }
    public void LeftLegFriction()
    {
        leftLeg.material = _defaulFriction;
        rightLeg.material = _zeroFriction;
    }
    public void RightLegFriction()
    {
        rightLeg.material = _defaulFriction;
        leftLeg.material = _zeroFriction;
    }
    public void FrictionChangeUpRightLeg()
    {
       
    }
    public void FrictionChangeZeroRightLeg()
    {
       
    }
    public void Update()
    {
        for (int i = 0; i < rb.LongLength; i++)
        {
            rb[i].mass = rbMass[i];
            rb[i].drag = rbDrag[i];
        }
    }

}
