using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ECC_521
{
    internal class Program
    {
        //identify NIST curve to use
        private const string curveName = "P-521";

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //run the application
            run();
        }



        //--------------------------------------------------------------------------------------------------



        /// <summary>
        /// Method to run the application
        /// </summary>
        private static void run()
        {
            try
            {
                //variable to hold curve values
                ECDomainParameters eCurve = null;

                //define the curve to be used for all key generations
                DefineCurve(out eCurve);
            }
            catch (Exception ex)
            {
                WriteLine($"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Method to define the curve
        /// </summary>
        /// <param name="eCurve"></param>
        private static void DefineCurve(out ECDomainParameters domainParameters)
        {
            //generating the curve parameters based on the NIST name fed
            X9ECParameters ecParameters = NistNamedCurves.GetByName(curveName);

            //cast general ECurve to FpCurve object over a prime field
            var generatedCurve = (FpCurve)ecParameters.Curve;

            //encapsulate the curve parameters of CURVE, BASE POINT, ORDER, COFACTOR, and SEED
            domainParameters = new ECDomainParameters(generatedCurve, ecParameters.G, ecParameters.N, ecParameters.H, ecParameters.GetSeed());
        }   
    }
}
//---------------....oooOO0_END_OF_FILE_0OOooo....---------------\\