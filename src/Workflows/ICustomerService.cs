using System;
using System.Workflow.Activities;

namespace Workflows
{
    [ExternalDataExchange]
	public interface ICustomerService
	{
        event EventHandler<ExternalDataEventArgs> Approved;
        event EventHandler<ExternalDataEventArgs> Rejected;
	}
}
