// Author: E Aubain
// Developer: Darkhitori

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lexic;

namespace Darkhitori.PlaymakerActions._NameGenerator
{
    using HutongGames.PlayMaker;

    [ActionCategory("NameGenerator")]
    [Tooltip("The name of a class inheriting from BaseNames and implementing its methods.")]
    public class NamesSourceClass : FsmStateAction
    {
        #region Variables
        [RequiredField]
        [CheckForComponent(typeof(NameGenerator))]
        public FsmOwnerDefault gameObject;
        
        public FsmString namesSourceClass;
        
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        
        NameGenerator nameGen;
        #endregion
        
        #region Reset Values
        public override void Reset()
        {
            gameObject = null;
            namesSourceClass = null;
            everyFrame = false;
        }
        #endregion
        
        #region Methods
        // Code that runs on entering the state.
        public override void OnEnter()
        {
            DoMethod();
            if (!everyFrame)
            {
                Finish();
            }
        }

        // Code that runs every frame.
        public override void OnUpdate()
        {
            DoMethod();
        }

        void DoMethod()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(go == null)
            {
                return;
            }
            
            nameGen = go.GetComponent<NameGenerator>();
            nameGen.namesSourceClass = namesSourceClass.Value;
        }
        #endregion
    }

}
