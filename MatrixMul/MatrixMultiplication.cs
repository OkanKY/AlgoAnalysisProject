using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthims2.matrix
{
    class MatrixMultiplication
    {
        private  Random rnd;
        private double mulCount;
        private double chainMulCount;
        public MatrixMultiplication()
        {
            rnd = new Random();
            mulCount = 0;
            chainMulCount = 0;
        }
        public double getmulCount()
        { return mulCount; }
        public double getchainMulCount()
        { return chainMulCount; }
        public double[] createMatrix(int sayi)
        {
            double[] dizi = new double[sayi + 1];
            for (int i = 0; i <= sayi; i++)
                dizi[i] = rnd.Next(1, 10);
                
            return dizi;

        }
        public List<double[,]> genarateMatrix(double[] dizi, int sayi)
        {
            List<double[,]> matrices = new List<double[,]>();


            for (int k = 0; k < sayi; k++)
            {
                double[,] matris = new double[(int)dizi[k], (int)dizi[k + 1]];
                for (int m = 0; m < dizi[k]; m++)
                {
                    for (int j = 0; j < dizi[k + 1]; j++)
                    {
                        matris[m, j] = rnd.Next(0, 10);

                    }
                }
                matrices.Add(matris);


            }
            return matrices;
        }
        public String multiDisplayMatrix(List<double[,]> matrices)
        {
            String disp = "";
            for (int a = 0; a < matrices.Count(); a++)
            {

                double[,] matris = matrices[a];
                disp += "Number of Matrix : " + (a + 1) + " Size: " + matris.GetLength(0) + "," + matris.GetLength(1) + " \n";
                disp+=displayMatrix(matris);

            }
            return disp;
        }
        public String displayMatrix(double[,] matris)
        {
            int rowLength = matris.GetLength(0);
            int colLength = matris.GetLength(1);
            String disp = "";
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    disp+=(string.Format("{0} ", matris[i, j]));
                }
                disp+=(Environment.NewLine + Environment.NewLine);
            }
            return disp;
        }
        public double[,] multiMatrixMultiplication(List<double[,]> matrices)
        {
            double[,] result = null;
            mulCount = 0;
            if (matrices.Count() > 1)
            {
                result = matrixMultiplication(matrices[0], matrices[1]);
                for (int i = 2; i < matrices.Count(); i++)
                {
                    result = matrixMultiplication(result, matrices[i]);
                }
            }
            return result;
        }

        public double[,] matrixMultiplication(double[,] matrixA, double[,] matrixB)
        {
            double[,] result = null;
            if (matrixA.GetLength(1) == matrixB.GetLength(0))
            {
                result = new double[matrixA.GetLength(0), matrixB.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = 0;
                        for (int k = 0; k < matrixA.GetLength(1); k++)
                        {
                            result[i, j] = result[i, j] + matrixA[i, k] * matrixB[k, j];
                            mulCount++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\n Number of columns in Matrix1 is not equal to Number of rows in Matrix2.");
            }

            return result;
        }
        public double[,] matrixChainOrder(double[] p, int n)
        {

            double[,] m = new double[n + 1, n + 1];
            double[,] s = new double[n + 1, n + 1];
            // Initial the cost for the empty subproblems.
            for (int i = 1; i <= n; i++)
                m[i, i] = 0;

            // Solve for chains of increasing length l.
            for (int l = 2; l <= n; l++)
            {
                for (int i = 1; i <= n - l + 1; i++)
                {
                    int j = i + l - 1;
                    m[i, j] = double.MaxValue;

                    // Check each possible split to see if it's better
                    // than all seen so far.
                    for (int k = i; k < j; k++)
                    {
                        double q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (q < m[i, j])
                        {
                            // q is the best split for this subproblem so far.
                            m[i, j] = q;
                            s[i, j] = k;
                        }
                    }
                }
            }
            chainMulCount= m[1, n];
            return s;
        }
        public String printOptimalParens(int i, int j, double[,] s)
        {
            if (i == j)
            {
                return "A[" + i + "]";
            }
            else
                return "(" + printOptimalParens(i, (int)s[i, j], s) +
                printOptimalParens((int)s[i, j] + 1, j, s) + ")";
        }
        public double[,] MultiplyOptimalParens(List<double[,]> matrices, double[,] s, int i, int j)
        {
            double[,] matrix1;
            double[,] matrix2;

            if (i == j)
                return matrices[i - 1];
            else
            {

                matrix1 = MultiplyOptimalParens(matrices, s, i, (int)s[i, j]);
                matrix2 = MultiplyOptimalParens(matrices, s, (int)s[i, j] + 1, j);
                //multiply two matrices together
                double[,] multiply = matrixMultiplication(matrix1, matrix2);
                return multiply;
            }
        }
        public void fileWriter(String write, String file)
        {

            try
            {
                StreamWriter dosya = File.CreateText("E:\\" + file + ".txt");
                dosya.WriteLine(write);
                dosya.Close();
            }
            catch (Exception e)
            {
                
                //throw (e);
            }

        }

    }
}
