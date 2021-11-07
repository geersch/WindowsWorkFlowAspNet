using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Workflows
{
    partial class CustomerApprovalWorkflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            this.codeActivityCreateAccount = new System.Workflow.Activities.CodeActivity();
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivityDeleteCustomer = new System.Workflow.Activities.CodeActivity();
            this.delayActivity = new System.Workflow.Activities.DelayActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivityRejectCustomer = new System.Workflow.Activities.CodeActivity();
            this.handleRejection = new System.Workflow.Activities.HandleExternalEventActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivityApproveCustomer = new System.Workflow.Activities.CodeActivity();
            this.handleApproval = new System.Workflow.Activities.HandleExternalEventActivity();
            this.stateInitializationActivity = new System.Workflow.Activities.StateInitializationActivity();
            this.onTimeout = new System.Workflow.Activities.EventDrivenActivity();
            this.onRejected = new System.Workflow.Activities.EventDrivenActivity();
            this.onApproved = new System.Workflow.Activities.EventDrivenActivity();
            this.Completed = new System.Workflow.Activities.StateActivity();
            this.Initial = new System.Workflow.Activities.StateActivity();
            // 
            // codeActivityCreateAccount
            // 
            this.codeActivityCreateAccount.Name = "codeActivityCreateAccount";
            this.codeActivityCreateAccount.ExecuteCode += new System.EventHandler(this.codeActivityCreateAccount_ExecuteCode);
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "Completed";
            // 
            // codeActivityDeleteCustomer
            // 
            this.codeActivityDeleteCustomer.Name = "codeActivityDeleteCustomer";
            this.codeActivityDeleteCustomer.ExecuteCode += new System.EventHandler(this.codeActivityDeleteCustomer_ExecuteCode);
            // 
            // delayActivity
            // 
            this.delayActivity.Name = "delayActivity";
            this.delayActivity.TimeoutDuration = System.TimeSpan.Parse("00:00:00");
            this.delayActivity.InitializeTimeoutDuration += new System.EventHandler(this.delayActivity_InitializeTimeoutDuration);
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "Completed";
            // 
            // codeActivityRejectCustomer
            // 
            this.codeActivityRejectCustomer.Name = "codeActivityRejectCustomer";
            this.codeActivityRejectCustomer.ExecuteCode += new System.EventHandler(this.codeActivityRejectCustomer_ExecuteCode);
            // 
            // handleRejection
            // 
            this.handleRejection.EventName = "Rejected";
            this.handleRejection.InterfaceType = typeof(Workflows.ICustomerService);
            this.handleRejection.Name = "handleRejection";
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "Completed";
            // 
            // codeActivityApproveCustomer
            // 
            this.codeActivityApproveCustomer.Name = "codeActivityApproveCustomer";
            this.codeActivityApproveCustomer.ExecuteCode += new System.EventHandler(this.codeActivityApproveCustomer_ExecuteCode);
            // 
            // handleApproval
            // 
            this.handleApproval.EventName = "Approved";
            this.handleApproval.InterfaceType = typeof(Workflows.ICustomerService);
            this.handleApproval.Name = "handleApproval";
            // 
            // stateInitializationActivity
            // 
            this.stateInitializationActivity.Activities.Add(this.codeActivityCreateAccount);
            this.stateInitializationActivity.Name = "stateInitializationActivity";
            // 
            // onTimeout
            // 
            this.onTimeout.Activities.Add(this.delayActivity);
            this.onTimeout.Activities.Add(this.codeActivityDeleteCustomer);
            this.onTimeout.Activities.Add(this.setStateActivity3);
            this.onTimeout.Name = "onTimeout";
            // 
            // onRejected
            // 
            this.onRejected.Activities.Add(this.handleRejection);
            this.onRejected.Activities.Add(this.codeActivityRejectCustomer);
            this.onRejected.Activities.Add(this.setStateActivity2);
            this.onRejected.Name = "onRejected";
            // 
            // onApproved
            // 
            this.onApproved.Activities.Add(this.handleApproval);
            this.onApproved.Activities.Add(this.codeActivityApproveCustomer);
            this.onApproved.Activities.Add(this.setStateActivity1);
            this.onApproved.Name = "onApproved";
            // 
            // Completed
            // 
            this.Completed.Name = "Completed";
            // 
            // Initial
            // 
            this.Initial.Activities.Add(this.onApproved);
            this.Initial.Activities.Add(this.onRejected);
            this.Initial.Activities.Add(this.onTimeout);
            this.Initial.Activities.Add(this.stateInitializationActivity);
            this.Initial.Name = "Initial";
            // 
            // CustomerApprovalWorkflow
            // 
            this.Activities.Add(this.Initial);
            this.Activities.Add(this.Completed);
            this.CompletedStateName = "Completed";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "Initial";
            this.Name = "CustomerApprovalWorkflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private SetStateActivity setStateActivity2;
        private CodeActivity codeActivityRejectCustomer;
        private HandleExternalEventActivity handleRejection;
        private SetStateActivity setStateActivity1;
        private CodeActivity codeActivityApproveCustomer;
        private HandleExternalEventActivity handleApproval;
        private EventDrivenActivity onTimeout;
        private EventDrivenActivity onRejected;
        private EventDrivenActivity onApproved;
        private StateActivity Completed;
        private DelayActivity delayActivity;
        private SetStateActivity setStateActivity3;
        private CodeActivity codeActivityDeleteCustomer;
        private CodeActivity codeActivityCreateAccount;
        private StateInitializationActivity stateInitializationActivity;
        private StateActivity Initial;
















    }
}
