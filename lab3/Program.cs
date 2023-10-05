

using System;
using System.Collections.Specialized;



public class Vector
{
    public double X, Y, Z;

    public Vector(double x, double y, double z)
    {
        X = x; Y = y; Z = z;
    }
    public static Vector operator +(Vector v1, Vector v2)
        => new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

    public static Vector operator *(Vector v1, Vector v2)
       => new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);

     public static Vector operator *(double num, Vector v2)
       => new Vector(num * v2.X, num * v2.Y, num * v2.Z);
    public static Vector operator *(Vector v, double num)
       => num * v;


    public static bool operator >(Vector v1, Vector v2)
      => Math.Sqrt(Math.Pow(v1.X,2) + Math.Pow(v1.Y, 2) + Math.Pow(v1.Z, 2)) > Math.Sqrt(Math.Pow(v2.X, 2) + Math.Pow(v2.Y, 2) + Math.Pow(v2.Z, 2));

    public static bool operator <(Vector v1, Vector v2)
     => Math.Sqrt(Math.Pow(v1.X, 2) + Math.Pow(v1.Y, 2) + Math.Pow(v1.Z, 2)) < Math.Sqrt(Math.Pow(v2.X, 2) + Math.Pow(v2.Y, 2) + Math.Pow(v2.Z, 2));

}

public class Car: IEquatable<Car>
{
    public string Name, Engine;
    public int MaxSpeed;


    /*public Car(string Name, string Engine, int MaxSpeed) 
    {
        this.Name = Name;
        this.Engine = Engine;
        this.MaxSpeed = MaxSpeed;
    } */
    public override string ToString() => this.Name;

    public static bool operator >(Car c1, Car c2)
      => c1.MaxSpeed > c2.MaxSpeed;
    public static bool operator <(Car c1, Car c2)
     => c1.MaxSpeed < c2.MaxSpeed;

    /* public string IEquatable(Car c1, Car c2)
     {

     }  */

    public bool Equals(Car? other) => (MaxSpeed == other.MaxSpeed && Name == other.Name && Engine == other.Engine);
   
}

public class CarsCatalog: Car
{
    public List<Car> cars = new List<Car>();
    public CarsCatalog(params Car[] list)
    {
        for (int i = 0; i < list.Length; i++) cars.Add(list[i]);
    }

    public string this[int index]
    {
        get { return cars[index].Name + cars[index].Engine; }
    }

}

public class Currency
{
    public double value;

    public Currency(double value)
    {
        this.value = value;
    }

   

}

public class CurrencyUSD : Currency
{
    public double value;


    public CurrencyUSD(double value) : base(value) {}

   public static implicit operator CurrencyEUR(CurrencyUSD cur) 
    {
        double NewValue = cur.value * 1.05; 
        CurrencyEUR cur1 = new CurrencyEUR(NewValue);
        return cur1;
        
    }
    public static implicit operator CurrencyRUB(CurrencyUSD cur)
    {
        double NewValue = cur.value * 99.77;
        CurrencyRUB cur1 = new CurrencyRUB(NewValue);
        return cur1;

    }

}

public class CurrencyEUR: Currency
{
    public double value;

    public CurrencyEUR(double value) : base(value) { }

    public static implicit operator CurrencyUSD(CurrencyEUR cur)
    {
        double NewValue = cur.value * 0.95;
        CurrencyUSD cur1 = new CurrencyUSD(NewValue);
        return cur1;

    }
    public static implicit operator CurrencyRUB(CurrencyEUR cur)
    {
        double NewValue = cur.value * 105.09;
        CurrencyRUB cur1 = new CurrencyRUB(NewValue);
        return cur1;

    }


}

public class CurrencyRUB: Currency
{
    public double value;
    public CurrencyRUB(double value) : base(value) { }

    public static implicit operator CurrencyUSD(CurrencyRUB cur)
    {
        double NewValue = cur.value * 0.01;
        CurrencyUSD cur1 = new CurrencyUSD(NewValue);
        return cur1;

    }
    public static implicit operator CurrencyEUR(CurrencyRUB cur)
    {
        double NewValue = cur.value * 0.0095;
        CurrencyEUR cur1 = new CurrencyEUR(NewValue);
        return cur1;

    }
}

