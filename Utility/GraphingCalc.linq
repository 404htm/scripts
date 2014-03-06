<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	var b = new Bitmap(800,200, System.Drawing.Imaging.PixelFormat.Format16bppArgb1555);
	b.Graph((x) => Math.Sin(x), Color.LightGray, -1000, 1000);
	b.Graph((x) => Math.Tan(x), Color.Green, -10, 10);
	b.Graph((x) => Math.Cos(x), Color.OrangeRed, -10,10);
	b.Dump();
}
public static class GraphingCalc
{
    public static void Graph(this Bitmap b, Func<double,double> func, Color color, int xs, int xe)
    {
       double ys = func.Min(xs,xe);
       double ye = func.Max(xs,xe);
       double yRange = ye - ys;
       double xRange = xe - xs;
       
       double xMult = xRange / b.Width;
       double yMult = yRange/ b.Height;
   
        int? ylast = null;
        
        for (int x = 0; x < b.Width; x++)
        {
            double xval = x * xMult + xs;
            double yval = func(xval);
            int y = (int)Math.Round((yval - ys) / yMult);
            y = Math.Max(0,Math.Min(b.Height-1,y));
            
            
            do
            {
                if (ylast == null) ylast=y;
                b.SetPixel(x,ylast.Value,color);
                if (ylast > y) ylast--; else if (ylast < y) ylast++;
            }
            while (ylast != null && ylast.Value != y);
            
            
        }
        
        
    }
    
    public static double Min(this Func<double,double> func, int start, int end)
    {
         return Enumerable.Range(start, end - start).Min(x => func(x));
    }
    
     public static double Max(this Func<double,double> func, int start, int end)
    {
         return Enumerable.Range(start, end - start).Max(x => func(x));
    }
}



// Define other methods and classes here