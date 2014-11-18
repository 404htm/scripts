<Query Kind="Program">
  <NuGetReference>MathNet.Numerics</NuGetReference>
  <Namespace>MathNet.Numerics</Namespace>
  <Namespace>MathNet.Numerics.Algorithms.LinearAlgebra</Namespace>
  <Namespace>MathNet.Numerics.IntegralTransforms</Namespace>
  <Namespace>MathNet.Numerics.Integration</Namespace>
  <Namespace>MathNet.Numerics.Random</Namespace>
  <Namespace>MathNet.Numerics.LinearAlgebra.Double</Namespace>
</Query>

void Main()
{
	var features = DenseMatrix.OfArray(new double[,]{
	{2104, 5, 1, 45, 460},
	{1416, 3, 2, 40, 232},
	{1534, 3, 2, 30, 315},
	{852,  2, 1, 36, 178}});
	
	
	var ones = DenseMatrix.Create(features.RowCount, 1, (a,b) => 1d);
	var X= ones.Append(features).SubMatrix(0,features.RowCount, 0, features.ColumnCount);
	var y = features.Column(features.ColumnCount -1);
	X.Dump();
	y.Dump();
	
	
	var x = X.Row(3).Dump();
	
	var T = (X.Transpose() * X).Inverse() * X.Transpose() * y;
	var h = DenseMatrix.OfRowVectors(T) * x;
	
	T.Dump();
	
	h.Dump();
}

// Define other methods and classes here
