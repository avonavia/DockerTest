using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DockerRunner
{
    class Program
    {
        public static string cID { get; set; }
        static async Task Main()
        {
            DockerClient client = new DockerClientConfiguration(
            new Uri("npipe://./pipe/docker_engine")).CreateClient();

            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters { All = true });

            var found = false;

            foreach (var c in containers)
            {
                if (c.Image == "dockermvctest:latest")
                {
                    found = true;
                    cID = c.ID;
                }
            }
            if (!found)
            {
                Console.WriteLine("Container not found");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine("Container found!");
            Console.WriteLine("Communicating to a container with ID: " + cID);
            await client.Containers.StartContainerAsync(cID, new ContainerStartParameters { });
            Console.WriteLine("Success");

            var containersUpd = await client.Containers.ListContainersAsync(new ContainersListParameters { All = true });

            found = false;

            System.Threading.Thread.Sleep(2000);

            foreach (var c in containersUpd)
            {
                if (c.ID == cID && c.State == "running")
                {
                    found = true;
                    foreach (var p in c.Ports)
                    {
                        if (p.PublicPort != 0)
                        {
                            var link = "http://localhost:" + p.PublicPort.ToString();
                            Console.WriteLine("Opening MVC App using address: " + link);
                            Process.Start(link);
                            Console.ReadKey();
                        }
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Error");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
