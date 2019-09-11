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

  }
}