using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpFundamental.keywork;

namespace CSharpFundamental.Struct
{
    class StructDemo
    {
        private void TestStruct()
        {
            var vectorClass = new VectorClass();
            var tempVector = vectorClass.GetVector();
            // GetVector 得到的是一个值，而不是一个变量。
            tempVector.x = 1;
        }

        private void TestClass()
        {
            var matrixClass = new MatrixClass();
            var tempMatrix = matrixClass.GetMatrix();
            tempMatrix.x = 1;// 为什么会报空指针错误
        }

        public void RunTheTest()
        {
            TestStruct();

            TestClass();
        }
    }

    struct Vector
    {
        public int x;
        public int y;
    }

    class Matrix
    {
        public int x;
        public int y;
    }

    class MatrixClass
    {
        private Matrix _matrix;

        public Matrix GetMatrix()
        {
            return _matrix;
        }

        public void SetMatrix(Matrix matrix)
        {
            _matrix = matrix;
        }

        public void ShowMatrix()
        {
            Console.WriteLine("Matrix: " + _matrix.x + "|" + _matrix.y);
        }
    }

    class VectorClass
    {
        private Vector _vector;

        public Vector GetVector()
        {
            return _vector;
        }

        public void SetVector(Vector vector)
        {
            _vector = vector;
        }

        public void ShowVector()
        {
            Console.WriteLine("Vector: " + _vector.x + "|" + _vector.y);
        }
    }
}
