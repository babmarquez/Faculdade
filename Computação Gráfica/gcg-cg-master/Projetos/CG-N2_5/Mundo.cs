using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using CG_Biblioteca;
using OpenTK.Input;
using System.Collections.Generic;

namespace CG_N2_5
{
  public class Mundo : GameWindow
  {
    /*
    Crie uma nova aplicação com o objetivo de poder mover um Segmento de Reta (SR), 
    aqui conhecido com Sr. "Palito", lateralmente usando as teclas Q (esquerda) e W (Direita). 
    Ao iniciar a aplicação um dos pontos do Sr. Palito está na origem. O segundo ponto do 
    Sr. Palito será definido com raio de valor 100 e ângulo 45º. Ainda é possível usar as 
    teclas A (diminuir) e S (aumentar) para mudar  o tamanho (raio), e as teclas Z (diminuir) 
    e X (aumentar) para girar (ângulo) do Sr. Palito. Olhe o exemplo no vídeo a baixo. 
    Lembre de usar a classe SegReta já definida no exercício anterior para desenhar o Sr. Palito.
    */

    public Mundo(int width, int height) : base(width, height) { }
    private Camera camera = new Camera();
    //Controle do sr. palito
    private int fx, fy, sx, sy;

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

      fx = 0;
      fy = 0;
      sx = 50;
      sy = 50;
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
      GL.Vertex2(0, 0);
      GL.Vertex2(200, 0);
      GL.Color3(Color.Green);
      GL.Vertex2(0, 0);
      GL.Vertex2(0, 200);
      GL.End();

      GL.Color3(Color.Black);
      GL.LineWidth(10);
      GL.Begin(PrimitiveType.Lines);
      GL.Vertex2(fx, fy);
      GL.Vertex2(sx, sy);
      GL.End();

      this.SwapBuffers();
    }
    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        Exit();
      //Esquerda
      else if (e.Key == Key.Q) {
        fx--; sx--;
      }
      //Direita
      else if (e.Key == Key.W) {
        fx++; sx++;
      }
      /*Arquivo pro professor foi com isso invertido */
      //Diminuir raio
      else if (e.Key == Key.A) {
        sy--; sx--;
      }
      //Aumentar raio
      else if (e.Key == Key.S) {
        sy++; sx++;
      }
      /* ------------------- */
      //Diminuir
      else if (e.Key == Key.Z) {
        var a = Matematica.GerarPtosCirculo(Matematica.angle(fx, fy, sx, sy) - 1, Matematica.distance(fx, sx, fy, sy), 0, 0);
        sy = Convert.ToInt32(a.Y);
        sx = Convert.ToInt32(a.X);
      }
      //Aumentar
      else if (e.Key == Key.X) {
        var a = Matematica.GerarPtosCirculo(Matematica.angle(fx, fy, sx, sy) + 1, Matematica.distance(fx, sx, fy, sy), 0, 0);
        sy = Convert.ToInt32(a.Y);
        sx = Convert.ToInt32(a.X);
      }
    }
  }
}
