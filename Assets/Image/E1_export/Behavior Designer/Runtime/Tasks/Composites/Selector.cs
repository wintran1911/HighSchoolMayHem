﻿namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Selector task trả về True khi 1 trong các tác vụ con của nó trả về True " +
                     "Nếu tác vụ con trả về Fail nó sẽ chạy tiếp theo tuần tự cho đến khi hết. nếu không có Task nào True thì nó trả về Fail")]
    //[TaskDescription("The selector task is similar to an \"or\" operation. It will return success as soon as one of its child tasks return success. " +
    //                 "If a child task returns failure then it will sequentially run the next task. If no child task returns success then it will return failure.")]
    [TaskIcon("{SkinColor}SelectorIcon.png")]
    public class Selector : Composite
    {
        // The index of the child that is currently running or is about to run.
        private int currentChildIndex = 0;
        // The task status of the last child ran.
        private TaskStatus executionStatus = TaskStatus.Inactive;

        public override int CurrentChildIndex()
        {
            return currentChildIndex;
        }

        public override bool CanExecute()
        {
            // We can continue to execuate as long as we have children that haven't been executed and no child has returned success.
            return currentChildIndex < children.Count && executionStatus != TaskStatus.Success;
        }

        public override void OnChildExecuted(TaskStatus childStatus)
        {
            // Increase the child index and update the execution status after a child has finished running.
            currentChildIndex++;
            executionStatus = childStatus;
        }

        public override void OnConditionalAbort(int childIndex)
        {
            // Set the current child index to the index that caused the abort
            currentChildIndex = childIndex;
            executionStatus = TaskStatus.Inactive;
        }

        public override void OnEnd()
        {
            // All of the children have run. Reset the variables back to their starting values.
            executionStatus = TaskStatus.Inactive;
            currentChildIndex = 0;
        }
    }
}