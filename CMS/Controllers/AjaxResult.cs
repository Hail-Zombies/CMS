using System.Net.NetworkInformation;
using System.Text;

namespace CMS.Controllers
{
    public class AjaxResult
    {
        public bool res;
        public string message;

        public AjaxResult()
        {
        }

        public AjaxResult(bool res, string message)
        {
            this.res = res;
            this.message = message;
        }

        public static bool PingSQLServer()
        {
            // 主机地址
            string targetHost = "192.168.57.128";
            string data = " ";

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions
            {
                DontFragment = true
            };

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1024;

            PingReply reply = pingSender.Send(targetHost, timeout);

            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}