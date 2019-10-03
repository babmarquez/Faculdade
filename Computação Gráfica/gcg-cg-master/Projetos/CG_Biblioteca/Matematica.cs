/*
  Autor: Dalton Solano dos Reis
*/

using System;

namespace CG_Biblioteca
{
  /// <summary>
  /// Classe com funções matemáticas.
  /// </summary>
  public class Matematica {
    /// <summary>
    /// Função para calcular um ponto sobre o perímetro de um círculo informando um ângulo e raio.
    /// </summary>
    /// <param name="angulo"></param>
    /// <param name="raio"></param>
    /// <returns></returns>
    public Ponto4D GerarPtosCirculo(double angulo, double raio) {
      Ponto4D pto = new Ponto4D();
      pto.X = (raio * Math.Cos(Math.PI * angulo / 180.0));
      pto.Y = (raio * Math.Sin(Math.PI * angulo / 180.0));
      pto.Z = 0;
      return(pto);
    }
    public static Ponto4D GerarPtosCirculo(double angulo, double raio, double centerx, double centery) {
      Ponto4D pto = new Ponto4D();
      pto.X = (raio * Math.Cos(Math.PI * angulo / 180.0))+centerx;
      pto.Y = (raio * Math.Sin(Math.PI * angulo / 180.0))+centery;
      pto.Z = 0;
      return(pto);
    }

    public double GerarPtosCirculoloSimétrico(double raio) {
      return (raio * Math.Cos(Math.PI * 45 / 180.0));
    }

    public static double angle(double cx, double cy, double ex, double ey) {
      var dy = ey - cy;
      var dx = ex - cx;
      var theta = Math.Atan2(dy, dx); // range (-PI, PI]
      theta *= 180 / Math.PI; // rads to degs, range (-180, 180]
      //if (theta < 0) theta = 360 + theta; // range [0, 360)
      return theta;
    }

    public static double distance(double x0, double x1, double y0, double y1) {
      double deltaX = x1 - x0;
      double deltaY = y1 - y0;
      double deltaZ = 0;
      double distance = (double) Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
      return distance;
    }

  }
}