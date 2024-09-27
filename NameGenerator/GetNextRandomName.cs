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
    [Tooltip("Will return a new procedurally generated name according to the syllables and rules of the dictionary.")]
    public class GetNextRandomName : FsmStateAction
    {
        #region Variables
        [RequiredField]
        [CheckForComponent(typeof(NameGenerator))]
        public FsmOwnerDefault gameObject;
        
        [UIHint(UIHint.Variable)]
        public FsmString randomName;
        
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;
        
        NameGenerator nameGen;
        #endregion
        
        #region Reset Values
        public override void Reset()
        {
            gameObject = null;
            randomName = null;
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
            
            randomName.Value = nameGen.GetNextRandomName();
        }
        #endregion
    }

}
