using System;
using System.Web;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using Workflows;

namespace WebApplication
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WorkflowRuntime runtime = new WorkflowRuntime("WorkflowRuntime");

            ExternalDataExchangeService exchangeService = new ExternalDataExchangeService();
            runtime.AddService(exchangeService);

            CustomerService customerService = new CustomerService();
            exchangeService.AddService(customerService);

            runtime.StartRuntime();

            Application["WorkflowRuntime"] = runtime;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            WorkflowRuntime runtime = Application["WorkflowRuntime"] as WorkflowRuntime;
            if (runtime != null)
            {
                runtime.StopRuntime();
                runtime.Dispose();
            }
        }
    }
}