/*
  Autor: Dalton Solano dos Reis
*/

using System;

namespace CG_Biblioteca
{
  public class Matematica {

    public static Ponto4D GerarPtosCirculo(double angulo, double raio) {
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