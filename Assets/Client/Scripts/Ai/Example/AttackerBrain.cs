using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Ai.Example
{
    public sealed class AttackerBrain : IAiBrain
    {
        int _state;
        AiData _aiData;
        AiController _aiController;


        public AttackerBrain(AiData aiData, AiController aiController)
        {
            _aiData = aiData;
            _aiController = aiController;
        }

        public void Enter()
        {
            _state = 0;
        }

        public void Execute()
        {
            if (_state == 0)
            {
                _aiController.SetState<PursuitAction>();
                _aiData.hasTarget = true;
                _aiData.targetTransform = _aiData.target.transform;
                _state++;
            }

            if (_state == 1)
            {
                if (_aiData.actionState == AiActionState.Complete)
                {
                    _aiController.SetState<Attack2Action>();
                    _aiData.hasTarget = true;
                    _aiData.targetTransform = _aiData.target.transform;
                    _state++;
                }
            }
            else if (_state == 2)
            {
                if (_aiData.actionState == AiActionState.Failed)
                {
                    _aiController.SetState<PursuitAction>();
                    _aiData.hasTarget = true;
                    _aiData.targetTransform = _aiData.target.transform;
                    _state--;
                }
            }
        }

        public void Exit()
        {
        }
    }
}
