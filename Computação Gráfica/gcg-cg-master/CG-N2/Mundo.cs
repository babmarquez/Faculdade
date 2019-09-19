using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Input;
using CG_Biblioteca;

namespace gcgcg
{
  class Mundo : GameWindow
  {
    public static Mundo instance = null;

    public Mundo(int width, int height) : base(width, height) { }

    public static Mundo getInstance()
    {
      if (instance == null)
        instance = new Mundo(600,600);
      return instance;
    }

    private Camera camera = new Camera();
    protected List<Objeto> objetosLista = new List<Objeto>();
    private bool moverPto = false;
    //FIXME: estes objetos não devem ser atributos do Mundo
    private Retangulo retanguloA, retanguloB;

    private Circulo circulo;
    
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      retanguloA = new Retangulo("A", new Ponto4D(50, 50, 0), new Ponto4D(150, 150, 0));
      
      objetosLista.Add(retanguloA);
      
      //Item que muda a cor para o cinza
      GL.ClearColor(Color.Gray);
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
      GL.LoadIdentity();

      Sru3D();

      for (var i = 0; i < objetosLista.Count; i++)
      {
        objetosLista[i].Desenhar();
      }

      this.SwapBuffers();
    }

    protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
    {
      if (e.Key == Key.Escape)
        Exit();
      else
      if (e.Key == Key.E)
      {
        for (var i = 0; i < objetosLista.Count; i++)
        {
          objetosLista[i].PontosExibirObjeto();
        }
      }
      else
      if (e.Key == Key.M)
      {
        moverPto = !moverPto;
      }
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
      if (moverPto)
      {
        retanguloB.MoverPtoSupDir(new Ponto4D(e.Position.X, 600 - e.Position.Y, 0));
      }
    }

    private void Sru3D()
    {
      GL.LineWidth(1);
      GL.Begin(PrimitiveType.Lines);
      GL.Color3(Color.Red);
      GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
      GL.Color3(Color.Green);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
      GL.Color3(Color.Blue);
      GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 200);
      GL.End();
    }

  }

  class Program
  {
    static void Main(string[] args)
    {
      Mundo window = new Mundo(600, 600);
      window.Title = "CG_Template";
      window.Run(1.0 / 60.0);
    }
  }

}
