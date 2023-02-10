using System;
namespace Activity
{
    interface SHMInterface
    {
        void pass_time(double time);
        void print_coords();
        void print_properties();
    }
    class SHM_function: SHMInterface
    {
        private double A;
        public double Amplitude
        {
            get { return A; }
            set 
            {
                A = value;
                update_coords();
            }
        }

        private double omega;
        public double Omega
        {
            get { return omega; }
            set 
            {
                omega = value;
                update_coords();
            }
        }

        private double phi;
        public double Phi
        {
            get { return phi; }
            set 
            {
                phi = value;
                update_coords();
            }
        }

        private double[] coords = { 0, 0, 0 };
        private double t;
        public double T
        {
            get { return t; }
            set { t = value; }
        }
        
        public double this[int i] //Can get position speed acceleration
        {
            get{return coords[i];}
        }
        public SHM_function() 
        {
            t = 0;
            A = 1;
            omega = Math.PI;
            phi = 0;
            update_coords();
        }
        public SHM_function( double amp, double freq, double p)
        {
            t = 0;
            A = amp;
            omega = freq;
            phi = p;
            update_coords();
        }

        public void pass_time(double n)
        {
            t += n;
            update_coords();
            print_coords();
        }
        public void print_coords()
        {
            Console.WriteLine("Current time is: " + t);
            Console.WriteLine("Position is: " + coords[0]);
            Console.WriteLine("Velocity is: " + coords[1]);
            Console.WriteLine("Acceleration is: " + coords[2]);
        }
        private void update_coords()
        {
            coords[0] = A * Math.Cos(omega * t + phi);
            coords[1] = -1 * A * omega * Math.Sin(omega * t + phi);
            coords[2] = -1 * A * omega * omega * Math.Cos(omega * t + phi);
        }

        public void print_properties()
        {
            Console.WriteLine("Amplitude: " + A);
            Console.WriteLine("Omega: " + omega);
            Console.WriteLine("Phi: " + phi);
        }
    }

    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Welcome! this program is designed to model Simple harmonic motion(ideal springs pendulums)");
            Console.WriteLine("The program was was written with spring mass system in mind, hence the command names.");
            Console.WriteLine("SHM is modeled by the equations x(t) = A * cos(omega * t + phi)");
            Console.WriteLine("Where A is amplitude, omega is angular frequency, phi is a shift");
            Console.WriteLine("The intial conditions are set to A=1 omega=1 phi=0");
            SHM_function f = new SHM_function(1, 1, 0);
            bool running = true;
            while (running)
            {
                Console.WriteLine("Type the command press Enter then enter the value");
                Console.WriteLine("Here's the command list:");
                Console.WriteLine("\tp - reads in a value to pass this amount of time");
                Console.WriteLine("\ts - reads in a value to set the time to");
                Console.WriteLine("\ta - reads in a value to set the amplitude to");
                Console.WriteLine("\to - reads in a value to set the omega to");
                Console.WriteLine("\tph - reads in a value to set the phi to");
                Console.WriteLine("\tq - quit");
                switch (Console.ReadLine())
                {
                    case "p":
                        double time = Convert.ToDouble(Console.ReadLine());
                        f.pass_time(time);
                        break; 
                    case "s":
                        double time2 = Convert.ToDouble(Console.ReadLine());
                        f.T = time2;
                        f.print_properties();
                        f.print_coords();
                        break;
                    case "a":
                        double amp = Convert.ToDouble(Console.ReadLine());
                        f.Amplitude = amp;
                        f.print_properties();
                        f.print_coords();
                        break;
                    case "o":
                        double om = Convert.ToDouble(Console.ReadLine());
                        f.Omega = om;
                        f.print_properties();
                        f.print_coords();
                        break;
                    case "ph":
                        double ph = Convert.ToDouble(Console.ReadLine());
                        f.Phi = ph;
                        f.print_properties();
                        f.print_coords();
                        break;
                    case "q":
                        running = false;
                        break;
                }
            }
        }
    }
}