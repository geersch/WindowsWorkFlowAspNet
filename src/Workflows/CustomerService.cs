using System;
using System.Workflow.Activities;

namespace Workflows
{
	public class CustomerService : ICustomerService
	{
        public event EventHandler<ExternalDataEventArgs> Approved;
        public event EventHandler<ExternalDataEventArgs> Rejected;

        private bool FireEvent(EventHandler<ExternalDataEventArgs> theEvent, ExternalDataEventArgs args)
        {
            if (theEvent != null)
            {
                try
                {
                    theEvent(null, args);
                }
                catch (EventDeliveryFailedException)
                {
                    return false;
                }
            }
            return true;
        }

        public bool OnApproved(Guid instanceId)
        {
            return FireEvent(Approved, new ExternalDataEventArgs(instanceId));
        }

        public bool OnRejected(Guid instanceId)
        {
            return FireEvent(Rejected, new ExternalDataEventArgs(instanceId));
        }
    }
}
