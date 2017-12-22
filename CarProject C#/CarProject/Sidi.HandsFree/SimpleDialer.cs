// Copyright (c) 2016, Andreas Grimme

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sidi.HandsFree
{
    public class SimpleDialer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ServiceLevelConnection slc = null;

        public SimpleDialer()
        {
        }
        public async Task Dial(string deviceName = null)
        {
            try
            {
                slc = await ServiceLevelConnection.Connect(deviceName);
                await slc.Establish();
            }
            catch (Exception e)
            {
                // Extract some information from this exception, and then   
                // throw it to the parent method.  
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
         }

        public ServiceLevelConnection getServiceBase() {
            return slc;
        }
    }
}
