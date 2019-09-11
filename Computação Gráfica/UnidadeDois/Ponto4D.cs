/*
  Autor: Dalton Solano dos Reis
*/
namespace CG_Biblioteca
{
  /// <summary>
  /// Classe que define um ponto no espaço 3D com a coordenada homogênea (w) da Transformação Geometrica
  /// </summary>
  public class Ponto4D
  {
    private double x;
    private double y;
    private double z;
    private readonly double w;
    /// <summary>
    /// Instância um ponto 3D com a coordenada homogênea w
    /// </summary>
    /// <param name="x">coordenada eixo x</param>
    /// <param name="y">coordenada eixo y</param>
    /// <param name="z">coordenada eixo z</param>
    /// <param name="w">coordenada espaço homogêneo</param>
    public Ponto4D(double x = 0.0, double y = 0.0, double z = 0.0, double w = 1.0)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = w;
    }
    public Ponto4D(Ponto4D pto) {
      this.x = pto.x;
      this.y = pto.y;
      this.z = pto.z;
    }
    // Operator overloaded
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pto1"></param>
    /// <param name="pto2"></param>
    /// <returns></returns>
    public static Ponto4D operator +(Ponto4D pto1, Ponto4D pto2) => new Ponto4D(pto1.X + pto2.X, pto1.Y + pto2.Y, pto1.Z + pto2.Z);

    //TODO: a sobreescreção do operador + funciona mais o - ou -- não
    // public static Ponto4D operator -(Ponto4D pto) => new Ponto4D(-pto.X, -pto.Y, -pto.Z);

    //TODO: Testar estas funções e ver se precisam existir
    // public static bool operator ==(Ponto4D pto1, Ponto4D pto2) {
    //   return ((pto1.X == pto2.X) && (pto1.Y == pto2.Y) && (pto1.Z == pto2.Z));
    // }
    // public static bool operator !=(Ponto4D pto1, Ponto4D pto2) {
    //   return ((pto1.X != pto2.X) && (pto1.Y != pto2.Y) && (pto1.Z != pto2.Z));
    // }
    /// <summary>
    /// Obter e atribuir a coordenada x
    /// </summary>
    /// <value>coordenada x</value>
    public double X { get => x; set => x = value; }
    /// <summary>
    /// Obter e atribuir a coordenada y
    /// </summary>
    /// <value>coordeanda y</value>
    public double Y { get => y; set => y = value; }
    /// <summary>
    /// Obter e atribuir a coordenada z
    /// </summary>
    /// <value>coordeanda z</value>
    public double Z { get => z; set => z = value; }
    /// <summary>
    /// Obter e atribuir a coordenada homogênea w
    /// </summary>
    /// <value>coordeanda w</value>
    public double W { get => w; }
/// <summary>
/// Inverte todos os valores das coordenadas do ponto
/// </summary>
    public void InverterSinal()
    {
      x *= -1;
      y *= -1;
      z *= -1;
    }
    //TODO: poderia sobreescrever o sinal negativo no lugar do "inverterSinal()".
    // public static Ponto4D operator -(Ponto4D pto) => new Ponto4D(-pto.X, -pto.Y, -pto.Z);

  }
}