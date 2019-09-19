using System;
using CG_Biblioteca;

namespace gcgcg
{
  internal class Circulo : ObjetoAramado
  {
    private Ponto4D ptoInfEsq, ptoSupDir;
    public Circulo(string rotulo, Ponto4D ptoInfEsq, Ponto4D ptoSupDir) : base(rotulo)
    {
      this.ptoInfEsq = ptoInfEsq;
      this.ptoSupDir = ptoSupDir;
      GerarPtosCirculo();
    }

    private void GerarPtosCirculo() {
      base.PontosRemoverTodos();
      base.PontosAdicionar(ptoInfEsq);
      base.PontosAdicionar(new Ponto4D(ptoSupDir.X,ptoInfEsq.Y));
      base.PontosAdicionar(ptoSupDir);
      base.PontosAdicionar(new Ponto4D(ptoInfEsq.X,ptoSupDir.Y));
    }

    public void MoverPtoSupDir(Ponto4D ptoMover) {
      ptoSupDir = ptoMover;
      GerarPtosCirculo();
    }
  }
}