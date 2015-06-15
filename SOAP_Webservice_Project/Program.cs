using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace SOAPwebservice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1  Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:49221/WCFsoap");

            // Step 2 : Create ServiceHost (this will host the webservice)
            ServiceHost selfHost = new ServiceHost(typeof(NextConcertDateWebservice), baseAddress);

            try
            {
                // Step 3 : Add a service endpoint.
                selfHost.AddServiceEndpoint(
                    typeof(INextConcertDate),        //Contract
                    new BasicHttpBinding(),        //Binding
                    "NextConcertDate");       //Address (relative to selfhost url)

                // Step 4 : Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Set IncludeExceptionDetailInFaults to true in code for WCF
                // http://stackoverflow.com/questions/2483178/set-includeexceptiondetailinfaults-to-true-in-code-for-wcf
                // I used this to allow return of exception details to SoapUI when calling for webservice
                // the exception was related to the fact that i needed to include the same connectionstring from web.config (in project 'CA2') in app.config
                ServiceDebugBehavior debug = selfHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                // if not found - add behavior with setting turned on 
                if (debug == null)
                {
                    selfHost.Description.Behaviors.Add(
                        // set to 'false' now that i have resolved the exception issue
                         new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = false });
                }
                else
                {
                    // make sure setting is turned ON
                    if (!debug.IncludeExceptionDetailInFaults)
                    {
                        //set to 'false' now that i have resolved the exception issue
                        debug.IncludeExceptionDetailInFaults = false;
                    }
                }


                // Step 5  Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.    Press <ENTER> to terminate service.");
                Console.ReadLine();   //service will run until user hits a key

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }


        }
    }
}
