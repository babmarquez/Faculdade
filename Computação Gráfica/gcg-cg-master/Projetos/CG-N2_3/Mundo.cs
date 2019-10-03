using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;

namespace CG_N2_3
{
  public class Mundo : GameWindow
  {
    /*
    Enunciado:
    Crie uma outra aplicação para fazer o desenho da imagem abaixo. Os círculos tem raio 
    com valor 100. Aqui utilize a classe Circulo já criada e crie uma nova classe com o 
    nome SegReta em  "SegReta.cs" para desenhar o triângulo. Utilize a operação soma para 
    deslocar o centro das circunferências para as posições apresentadas na imagem abaixo. 
    Esta soma não deve ser feita na classe Matematica, e sim ser informada no momento que 
    for criado o novo objeto do tipo Circulo, passando um Ponto4D de deslocamento (ptoCentro).
    */

    public Mundo(int width, int height) : base(width, height) { }
    private Camera camera = new Camera();

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      GL.ClearColor(Color.Gray);
      camera.xmin = -300;
      camera.xmax = 300;
      camera.ymin = -300;
      camera.ymax = 300;
      camera.zmin = 0;
      camera.zmax = 600;
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
      base.OnUpdateFrame(e);
      GL.MatrixMode(MatrixMode.Projection);
      GL.LoadIdentity();
      GL.Ortho(camera.xmin, camera.xmax, camera.ymin, camera.ymax, camera.zmin, camera.zmax);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
      base.OnRenderFrame(e);
      GL.Clear(ClearBufferMask.ColorBufferBit);
      GL.MatrixMode(MatrixMode.Modelview);
      GL.Color3(Color.Red);
      GL.LineWidth(10);
      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(0, 0); GL.Vertex2(200, 0);
      GL.Color3(Color.Green);
      GL.Vertex2(0, 0); GL.Vertex2(0, 200);
      GL.End();
      GL.PointSize(10);
      GL.Color3(Color.Black);
      GL.Begin(PrimitiveType.Points);
      //Cria os três circulos
      for (int i = 0; i < 360; i += 5)
      {
        var a = Matematica.GerarPtosCirculo(i, 100, 0, 100);
        GL.Vertex2(a.X, a.Y);
      }
      for (int i = 0; i < 360; i += 5)
      {
        var a = Matematica.GerarPtosCirculo(i, 100, 100, -100);
        GL.Vertex2(a.X, a.Y);
      }
      for (int i = 0; i < 360; i += 5)
      {
        var a = Matematica.GerarPtosCirculo(i, 100, -100, -100);
        GL.Vertex2(a.X, a.Y);
      }
      GL.End();
      GL.Color3(0, 0.9, 0.9);
      GL.LineWidth(10);
      //Cria o triângulo
      //Linha 1
      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(0, 100);
      GL.Vertex2(-100, -100);
      GL.End();
      //Linha 2
      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(-100, -100);
      GL.Vertex2(100, -100);
      GL.End();
      //Linha 3
      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(100, -100);
      GL.Vertex2(0, 100);
      GL.End();

      this.SwapBuffers();
    }
  }
}
