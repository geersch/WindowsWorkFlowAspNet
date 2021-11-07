using System;
using System.Workflow.Activities;
using Managers;

namespace Workflows
{
    public sealed partial class CustomerApprovalWorkflow : StateMachineWorkflowActivity
    {
        public string UserName { get; set; }

        public CustomerApprovalWorkflow()
        {
            InitializeComponent();
        }

        private void delayActivity_InitializeTimeoutDuration(object sender, EventArgs e)
        {
            ((DelayActivity)sender).TimeoutDuration = new TimeSpan(0, 1, 0);
        }

        private void codeActivityCreateAccount_ExecuteCode(object sender, EventArgs e)
        {
            CustomerManager manager = new CustomerManager();
            manager.AddCustomer(WorkflowInstanceId, UserName);
        }

        private void codeActivityApproveCustomer_ExecuteCode(object sender, EventArgs e)
        {
            CustomerManager manager = new CustomerManager();
            manager.ApproveCustomer(WorkflowInstanceId);
        }

        private void codeActivityRejectCustomer_ExecuteCode(object sender, EventArgs e)
        {
            CustomerManager manager = new CustomerManager();
            manager.RejectCustomer(WorkflowInstanceId);
        }

        private void codeActivityDeleteCustomer_ExecuteCode(object sender, EventArgs e)
        {
            CustomerManager manager = new CustomerManager();
            manager.DeleteCustomer(WorkflowInstanceId);
        }
    }
}
