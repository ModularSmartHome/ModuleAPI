using System.Net;
using System.Net.Sockets;

namespace DefaultNamespace;

public class TcpPortLookup
{

    public int GetUnusedPort()
    {
        int port = 5001;
        while (CheckPortIsFree(port) == false)
        {
            port += 1;
        }

        return port;
    }

    private bool CheckPortIsFree(int portno)
    {
        try
        {
            using (var client = new TcpClient("localhost", portno))
                return false;
        }
        catch (SocketException ex)
        {
            return true;
        }
    }
}