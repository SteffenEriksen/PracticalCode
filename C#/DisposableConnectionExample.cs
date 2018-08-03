using System;
    using Microsoft.Xrm.Sdk.Client;

    public class CustomerOnlineManager : IDisposable
    {
        private OrganizationServiceProxy _service;

        public CustomerOnlineManager(Uri crmOrganizationUri)
        {
            if (crmOrganizationUri == null)
            {
                throw new ArgumentNullException(nameof(crmOrganizationUri), "Can not be null or empty.");
            }

            _service = ManagerHelper.GetCrmOrganizationServiceProxy(crmOrganizationUri);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            try
            {
                if (_service == null) return;
                _service.Dispose();
                _service = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }