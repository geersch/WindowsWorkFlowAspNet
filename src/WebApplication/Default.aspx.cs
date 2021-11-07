using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using Database;
using Workflows;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            WorkflowRuntime runtime = (WorkflowRuntime) Application["WorkflowRuntime"];

            Dictionary<string, object> arguments = new Dictionary<string, object>();
            arguments.Add("UserName", txtUserName.Text.Trim());

            WorkflowInstance workflow = runtime.CreateWorkflow(typeof (CustomerApprovalWorkflow), arguments);
            workflow.Start();

            ManualWorkflowSchedulerService scheduler =
                (ManualWorkflowSchedulerService) runtime.GetService(typeof (ManualWorkflowSchedulerService));
            scheduler.RunWorkflow(workflow.InstanceId);

            gridCustomers.DataBind();
        }

        protected void gridCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Guid customerId = new Guid(e.CommandArgument.ToString());

            WorkflowRuntime runtime = (WorkflowRuntime) Application["WorkflowRuntime"];
            ManualWorkflowSchedulerService scheduler =
                (ManualWorkflowSchedulerService) runtime.GetService(typeof (ManualWorkflowSchedulerService));

            CustomerService customerService = (CustomerService) runtime.GetService<ICustomerService>();

            switch(e.CommandName)
            {
                case "Approve":
                    if (customerService.OnApproved(customerId))
                    {
                        scheduler.RunWorkflow(customerId);
                    }
                    break;
                case "Reject":
                    if (customerService.OnRejected(customerId))
                    {
                        scheduler.RunWorkflow(customerId);
                    }
                    break;
            }
            gridCustomers.DataBind();
        }

        protected void gridCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Customer customer = e.Row.DataItem as Customer;
            if (customer != null)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("linkReject");
                button.Enabled = customer.IsApproved == null;

                button = (LinkButton)e.Row.FindControl("linkApprove");
                button.Enabled = customer.IsApproved == null;
            }
        }
    }
}
