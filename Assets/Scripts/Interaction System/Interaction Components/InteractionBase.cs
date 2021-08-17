using UnityEngine;


namespace PointAndClick
{

    // base class for condition -> action system
    public abstract class InteractionBase : MonoBehaviour
    {
        public abstract bool IsConditionFulfilled();
        public abstract void Perform();
    }

    public class SavableInteraction : InteractionBase
    {
        public class InteractionSO : ScriptableObject
        {
            
        }


        public override bool IsConditionFulfilled()
        {
            throw new System.NotImplementedException();
        }

        public override void Perform()
        {
            throw new System.NotImplementedException();
        }
    }




}
