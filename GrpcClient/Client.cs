using System;
using System.Threading.Tasks;
using Grpc.Core;
using RimageUsbApi;

namespace GrpcClient
{
    public class Client
    {
 
        public async Task<GetJobsStatusResult> GetJobsStatus()
        {
            // Special alias to your host loopback interface (i.e., 127.0.0.1 on your development machine)
            var channel = new Channel("10.0.2.2", 55051, ChannelCredentials.Insecure);
            var client = new UsbApiService.UsbApiServiceClient(channel);
            // get job status 
            return await client.GetJobsStatusAsync(new GetJobsStatusRequest());
        }
    }
}
