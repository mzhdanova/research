using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;



namespace HSMPQApplication.Model
{
    class FergussonPolynomialModel
    {
        private double[] uA; //random number generator variable for transition matrix
        private double[] uB; //random number generator variable for output matrix
        private double[] uF; //random number generator variable for duration matrix
        private double lA;//the power of UA
        private double lB;//the power of UA
        private double lC;//the power of UA
        private int[,] fA;//coefficient of polinom fA
        private int[,] fB;//coefficient of polinom fB
        private int[,] fF;//coefficient of polinom fF
        private double[] Pi;
        //private int[,] cA;
        //private int[,] cB;
        //private int[,] cF;
        private int qA;
        private int qB;
        private int qF;
        public FergussonPolynomialModel(double[] uA, double[] uB,
            double[] uF, int[] fA, int[] fB, int[] fF)
        {
            //this.fA = fA;
            //this.fB = fB;
            //this.fF = fF;
            //this.uA = uA;
            //this.uB = uB;
            //this.uF = uF;
        }
 /*       public int[] generate(int n)
        {
            int[] res = new int[n];
            int k=0;
            int previousState = GeneratingUtils.ProbabilityMethod(Pi, PRNGMode.Random);
            int currentState;
            while (k < n)
            {
                int i = GeneratingUtils.ProbabilityMethod(uA, PRNGMode.Random);
                currentState = 

            }
            }*/

        public int polynom(int[,] coefficients, int x, int y)
        {
            int n = coefficients.GetLength(0);
            int result=0;
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    
                }
            }
            return 0;
        }

    }
}
