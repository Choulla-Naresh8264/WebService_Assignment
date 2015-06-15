using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// added a reference to System.ServiceModel (References => Add Reference)
using System.ServiceModel;

namespace SOAPwebservice
{
    // this interface acts as MEX (metadata exchange point) and 'describes' to the client what the api does.
    // this is the 'C' of ABC
    [ServiceContract]
    interface INextConcertDate
    {
        //describes name, input params, and output values
        [OperationContract]
        int findDate(int bandId);
    }
}
